using GameGuide.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameGuide.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Game>? Games { get; set; }
    public DbSet<Article>? Articles { get; set; }
    
}