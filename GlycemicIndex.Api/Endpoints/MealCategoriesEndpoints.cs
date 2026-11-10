using GlycemicIndex.Application;
using Microsoft.AspNetCore.Mvc;

namespace GlycemicIndex.Api.Endpoints;

public static class MealCategoriesEndpoints
{
    public static void MapMealCategoriesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/meal-categories", async (IMealCategoriesService mealCategoriesService) =>
        {
            var mealCategories = await mealCategoriesService.GetAllAsync();
            return Results.Ok(mealCategories);
        })
        .WithName("GetMealCategories");
        
        app.MapGet("/api/meal-categories/active", async (IMealCategoriesService mealCategoriesService) =>
        {
            var activeMealCategories = await mealCategoriesService.GetActiveAsync();
            return Results.Ok(activeMealCategories);
        })
        .WithName("GetActiveMealCategories");
        
        app.MapPut("/api/meal-categories/selection", async (IMealCategoriesService mealCategoriesService, [FromBody] int[] mealCategoryIds) =>
        {
            var selectedMealCategories = await mealCategoriesService.SaveSelectionAsync(mealCategoryIds);
            return Results.Ok(selectedMealCategories);
        })
        .WithName("SaveMealCategoriesSelection");
    }
}