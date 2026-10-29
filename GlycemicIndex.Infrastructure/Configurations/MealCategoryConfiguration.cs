using GlycemicIndex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlycemicIndex.Infrastructure.Configurations;

public class MealCategoryConfiguration : IEntityTypeConfiguration<MealCategory>
{
    public void Configure(EntityTypeBuilder<MealCategory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.IsEnabled)
            .IsRequired()
            .HasDefaultValue(true);
    }
}