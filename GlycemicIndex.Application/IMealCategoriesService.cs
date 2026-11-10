namespace GlycemicIndex.Application;

public interface IMealCategoriesService
{
    Task<IReadOnlyList<MealCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<MealCategoryDto>> GetActiveAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<MealCategoryDto>> SaveSelectionAsync(int[] enabledCategoryIds, CancellationToken cancellationToken = default);
}
