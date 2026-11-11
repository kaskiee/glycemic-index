namespace GlycemicIndex.Domain.Entities;

/// <summary>
/// A reusable, user-created composition of food products (e.g. "Oatmeal") that can be added to any meal.
/// A dish must contain at least two food products; a single product is logged directly as a meal entry.
/// </summary>
public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    /// <summary>
    /// How many portions the whole recipe makes (e.g. a pot of oatmeal made for 4 portions).
    /// Per-portion values are derived by dividing the recipe totals by this number.
    /// </summary>
    public decimal PortionCount { get; set; }

    public List<DishItem> Items { get; set; } = [];
}