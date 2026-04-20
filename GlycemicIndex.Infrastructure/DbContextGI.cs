using GlycemicIndex.Application;
using Microsoft.EntityFrameworkCore;

namespace GlycemicIndex.Infrastructure;

public class DbContextGI(DbContextOptions<DbContextGI> options) : DbContext(options), IDbContextGI;