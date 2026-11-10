using GlycemicIndex.Application.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GlycemicIndex.Application;

public sealed class MealCategoriesService(IDbContextGI context) : IMealCategoriesService
{
    private const int MaxEnabledCategories = 6;

    public async Task<IReadOnlyList<MealCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var categories = await context.MealCategories
            .AsNoTracking()
            .OrderBy(category => category.Id)
            .ToListAsync(cancellationToken);

        return categories.Select(x => x.ToDto()).ToList();
    }

    public async Task<IReadOnlyList<MealCategoryDto>> GetActiveAsync(CancellationToken cancellationToken = default)
    {
        var categories = await context.MealCategories
            .AsNoTracking()
            .Where(category => category.IsEnabled)
            .OrderBy(category => category.Id)
            .ToListAsync(cancellationToken);

        return categories.Select(x => x.ToDto()).ToList();
    }

    public async Task<IReadOnlyList<MealCategoryDto>> SaveSelectionAsync(int[] enabledCategoryIds, CancellationToken cancellationToken = default)
    {
        var selectedIds = (enabledCategoryIds ?? []).Distinct().ToArray();
        if (selectedIds.Length > MaxEnabledCategories)
        {
            throw new ArgumentException($"At most {MaxEnabledCategories} meal categories can be selected.");
        }

        var categories = await context.MealCategories.ToListAsync(cancellationToken);

        var unknownIds = selectedIds.Where(id => categories.All(category => category.Id != id)).ToArray();
        if (unknownIds.Length > 0)
        {
            throw new ArgumentException($"Unknown meal category ids: {string.Join(", ", unknownIds)}.");
        }

        foreach (var category in categories)
        {
            category.IsEnabled = selectedIds.Contains(category.Id);
        }

        await context.SaveChangesAsync(cancellationToken);

        return categories
            .OrderBy(category => category.Id)
            .Select(x => x.ToDto())
            .ToList();
    }
}