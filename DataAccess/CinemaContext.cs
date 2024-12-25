using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class CinemaContext(DbContextOptions<CinemaContext> options) : DbContext(options)
{
    public DbSet<Cinema> Cinemas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cinema>().HasKey(c => c.Id);

        base.OnModelCreating(modelBuilder);
    }
}