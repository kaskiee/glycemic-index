namespace GlycemicIndex.Domain.Entities;

/// <summary>One food product with its amount in grams inside a dish composition.</summary>
public class DishItem
{
    public int Id { get; set; }
    public int DishId { get; set; }
    public Dish Dish { get; set; } = null!;

    public int FoodProductId { get; set; }
    public FoodProduct FoodProduct { get; set; } = null!;

    public decimal QuantityGrams { get; set; }
}