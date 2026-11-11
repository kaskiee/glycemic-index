using GlycemicIndex.Application;
using GlycemicIndex.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlycemicIndex.Infrastructure;

public class DbContextGI(DbContextOptions<DbContextGI> options) : DbContext(options), IDbContextGI
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextGI).Assembly);
    }
    
    public DbSet<MealCategory> MealCategories { get; set; }
    public DbSet<FoodProduct> FoodProducts { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<DishItem> DishItems { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<MealEntry> MealEntries { get; set; }
}