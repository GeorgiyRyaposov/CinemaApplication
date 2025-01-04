using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class CinemaContext(DbContextOptions<CinemaContext> options) : DbContext(options)
{
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Details> Details { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cinema>().HasKey(x => x.Id);
        
        modelBuilder.Entity<Cinema>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<Cinema>().Property(x => x.Watched);

        modelBuilder.Entity<Cinema>()
            .HasOne<Details>(x => x.Details)
            .WithOne(x => x.Cinema)
            .HasForeignKey<Details>(x => x.CinemaId)
            .IsRequired(false);
        
        modelBuilder.Entity<Details>().HasKey(x => x.Id);
        modelBuilder.Entity<Details>()
            .HasOne<Cinema>(x => x.Cinema)
            .WithOne(x => x.Details)
            .HasForeignKey<Details>(x => x.CinemaId)
            .IsRequired(false);
        
        // modelBuilder.Entity<Details>().Property(x => x.AlternativeName);
        // modelBuilder.Entity<Details>().Property(x => x.Year);
        // modelBuilder.Entity<Details>().Property(x => x.Description);
        // modelBuilder.Entity<Details>().Property(x => x.ShortDescription);
        //
        // modelBuilder.Entity<Details>().Property(x => x.Length);
        // modelBuilder.Entity<Details>().Property(x => x.IsSeries);
        //
        // modelBuilder.Entity<Details>().Property(x => x.Genres);
        // modelBuilder.Entity<Details>().Property(x => x.Actors);
        // modelBuilder.Entity<Details>().Property(x => x.Countries);
        //
        // modelBuilder.Entity<Details>().Property(x => x.LogoUrl);
        // modelBuilder.Entity<Details>().Property(x => x.PreviewUrl);
        //
        // modelBuilder.Entity<Details>().Property(x => x.RatingImdb);
        // modelBuilder.Entity<Details>().Property(x => x.RatingKP);
        
        base.OnModelCreating(modelBuilder);
    }
}