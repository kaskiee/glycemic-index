using GlycemicIndex.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlycemicIndex.Application;

public interface IDbContextGI
{
    DbSet<MealCategory> MealCategories { get; set; }
}