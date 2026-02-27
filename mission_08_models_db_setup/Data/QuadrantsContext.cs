using Microsoft.EntityFrameworkCore;
using mission_08_models_db_setup.Models;

namespace mission_08_models_db_setup.Data;

public class QuadrantsContext : DbContext
{
    public QuadrantsContext(DbContextOptions<QuadrantsContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Home" },
            new Category { CategoryId = 2, Name = "School" },
            new Category { CategoryId = 3, Name = "Work" },
            new Category { CategoryId = 4, Name = "Church" }
        );
    }
}
