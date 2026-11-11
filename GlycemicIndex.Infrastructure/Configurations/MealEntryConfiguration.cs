using GlycemicIndex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlycemicIndex.Infrastructure.Configurations;

public class MealEntryConfiguration : IEntityTypeConfiguration<MealEntry>
{
    public void Configure(EntityTypeBuilder<MealEntry> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Meal)
            .WithMany(x => x.Entries)
            .HasForeignKey(x => x.MealId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.FoodProduct)
            .WithMany()
            .HasForeignKey(x => x.FoodProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Dish)
            .WithMany()
            .HasForeignKey(x => x.DishId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.QuantityGrams)
            .HasPrecision(7, 2);

        builder.Property(x => x.Portions)
            .HasPrecision(5, 2);

        builder.Property(x => x.Calories)
            .HasPrecision(7, 1);

        builder.Property(x => x.Protein)
            .HasPrecision(6, 2);

        builder.Property(x => x.Carbs)
            .HasPrecision(6, 2);

        builder.Property(x => x.Fat)
            .HasPrecision(6, 2);

        builder.Property(x => x.Fiber)
            .HasPrecision(6, 2);

        builder.Property(x => x.GlycemicIndex)
            .IsRequired();

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_MealEntries_Position_ProductXorDish",
                "(\"FoodProductId\" IS NOT NULL AND \"DishId\" IS NULL) OR (\"FoodProductId\" IS NULL AND \"DishId\" IS NOT NULL)");
            t.HasCheckConstraint("CK_MealEntries_QuantityGrams_Positive", "\"QuantityGrams\" > 0");
            t.HasCheckConstraint("CK_MealEntries_DishPortions_Required",
                "\"DishId\" IS NULL OR (\"Portions\" IS NOT NULL AND \"Portions\" > 0)");
            t.HasCheckConstraint("CK_MealEntries_Nutrition_NonNegative",
                "\"Calories\" >= 0 AND \"Protein\" >= 0 AND \"Carbs\" >= 0 AND \"Fat\" >= 0 AND \"Fiber\" >= 0");
        });
    }
}