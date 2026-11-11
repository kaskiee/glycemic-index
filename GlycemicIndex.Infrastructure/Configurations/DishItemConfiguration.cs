using GlycemicIndex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlycemicIndex.Infrastructure.Configurations;

public class DishItemConfiguration : IEntityTypeConfiguration<DishItem>
{
    public void Configure(EntityTypeBuilder<DishItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.FoodProduct)
            .WithMany()
            .HasForeignKey(x => x.FoodProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.QuantityGrams)
            .HasPrecision(7, 2);

        builder.ToTable(t => t.HasCheckConstraint("CK_DishItems_QuantityGrams_Positive", "\"QuantityGrams\" > 0"));
    }
}