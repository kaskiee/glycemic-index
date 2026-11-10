using GlycemicIndex.Domain.Entities;

namespace GlycemicIndex.Application.Mappings;

public static class MealCategoryMapping
{
    public static MealCategoryDto ToDto(this MealCategory category)
    {
        return new(category.Id, category.Name, category.IsEnabled);
    }
}