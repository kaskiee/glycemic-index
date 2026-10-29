namespace GlycemicIndex.Domain.Entities;

public class MealCategory
{
    public int Id  { get; set; }
    public string Name { get; set; } = null!;
    public bool IsEnabled { get; set; }
}