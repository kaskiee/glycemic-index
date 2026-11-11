using GlycemicIndex.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlycemicIndex.Application;

public interface IDbContextGI
{
    DbSet<MealCategory> MealCategories { get; set; }
    DbSet<FoodProduct> FoodProducts { get; set; }
    DbSet<Dish> Dishes { get; set; }
    DbSet<DishItem> DishItems { get; set; }
    DbSet<Meal> Meals { get; set; }
    DbSet<MealEntry> MealEntries { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}