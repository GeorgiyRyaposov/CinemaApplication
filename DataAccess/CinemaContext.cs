using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class CinemaContext(DbContextOptions<CinemaContext> options) : DbContext(options)
{
    public DbSet<Cinema> Cinemas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cinema>().HasKey(x => x.Id);
        
        modelBuilder.Entity<Cinema>().Property(x => x.Name).IsRequired();
        
        modelBuilder.Entity<Cinema>().Property(x => x.Description);
        
        modelBuilder.Entity<Cinema>().Property(x => x.Watched);
        
        base.OnModelCreating(modelBuilder);
    }
}