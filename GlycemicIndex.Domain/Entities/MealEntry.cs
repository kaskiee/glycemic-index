namespace GlycemicIndex.Domain.Entities;

/// <summary>
/// A single position logged in a meal: either a food product with a portion size in grams,
/// or a reusable dish logged by a number of portions. The nutrition values (including the
/// glycemic index) are snapshotted at the time the position is added, so the log stays
/// correct even if the food product's data or the dish recipe changes later.
/// </summary>
public class MealEntry
{
    public int Id { get; set; }
    public int MealId { get; set; }
    public Meal Meal { get; set; } = null!;
    
    public int? FoodProductId { get; set; }
    public FoodProduct? FoodProduct { get; set; }
    
    public decimal QuantityGrams { get; set; }

    public int? DishId { get; set; }
    public Dish? Dish { get; set; }

    /// <summary>Number of portions of the dish consumed (e.g. 1.5); set only for dish positions.</summary>
    public decimal? Portions { get; set; }

    /// <summary>Nutrition computed for the position when it was added (for dishes: per-portion values x Portions).</summary>
    public decimal Calories { get; set; }
    public decimal Protein { get; set; }
    public decimal Carbs { get; set; }
    public decimal Fat { get; set; }
    public decimal Fiber { get; set; }

    public int GlycemicIndex { get; set; }
}