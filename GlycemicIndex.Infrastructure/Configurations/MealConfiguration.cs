using GlycemicIndex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlycemicIndex.Infrastructure.Configurations;

public class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Date)
            .IsRequired();

        builder.HasOne(x => x.MealCategory)
            .WithMany()
            .HasForeignKey(x => x.MealCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Date);
    }
}