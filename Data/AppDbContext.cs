using Kimppakyydit.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Kimppakyydit.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Ride> Rides => Set<Ride>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Fix decimal precision warning for SQL Server
        modelBuilder.Entity<Ride>()
            .Property(r => r.Price)
            .HasPrecision(10, 2);
    }
}
