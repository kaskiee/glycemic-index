namespace GlycemicIndex.Domain.Entities;

public class FoodProduct
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int GlycemicIndex { get; set; }
    public decimal CaloriesPer100g { get; set; }
    public decimal ProteinPer100g { get; set; }
    public decimal CarbsPer100g { get; set; }
    public decimal FatPer100g { get; set; }
    public decimal FiberPer100g { get; set; }
}