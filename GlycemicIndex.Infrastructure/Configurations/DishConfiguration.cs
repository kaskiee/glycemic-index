using GlycemicIndex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlycemicIndex.Infrastructure.Configurations;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.PortionCount)
            .HasPrecision(5, 2);

        builder.HasIndex(x => x.Name);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Dish)
            .HasForeignKey(x => x.DishId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(t => t.HasCheckConstraint("CK_Dishes_PortionCount_Positive", "\"PortionCount\" > 0"));
    }
}