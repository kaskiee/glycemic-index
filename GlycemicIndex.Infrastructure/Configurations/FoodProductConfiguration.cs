using GlycemicIndex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlycemicIndex.Infrastructure.Configurations;

public class FoodProductConfiguration : IEntityTypeConfiguration<FoodProduct>
{
    public void Configure(EntityTypeBuilder<FoodProduct> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.GlycemicIndex)
            .IsRequired();

        builder.Property(x => x.CaloriesPer100g)
            .HasPrecision(6, 2);

        builder.Property(x => x.ProteinPer100g)
            .HasPrecision(5, 2);

        builder.Property(x => x.CarbsPer100g)
            .HasPrecision(5, 2);

        builder.Property(x => x.FatPer100g)
            .HasPrecision(5, 2);
        
        builder.Property(x => x.FiberPer100g)
            .HasPrecision(5, 2);

        builder.HasIndex(x => x.Name);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_FoodProducts_GlycemicIndex_Range", "\"GlycemicIndex\" BETWEEN 0 AND 100");
            t.HasCheckConstraint("CK_FoodProducts_Nutrition_NonNegative",
                "\"CaloriesPer100g\" >= 0 AND \"ProteinPer100g\" >= 0 AND \"CarbsPer100g\" >= 0 AND \"FatPer100g\" >= 0");
        });
    }
}