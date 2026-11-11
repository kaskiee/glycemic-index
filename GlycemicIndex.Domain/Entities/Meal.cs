namespace GlycemicIndex.Domain.Entities;

public class Meal
{
    public int Id { get; set; }

    /// <summary>Calendar day the meal belongs to.</summary>
    public DateOnly Date { get; set; }

    public int MealCategoryId { get; set; }
    public MealCategory MealCategory { get; set; } = null!;

    public List<MealEntry> Entries { get; set; } = [];
}