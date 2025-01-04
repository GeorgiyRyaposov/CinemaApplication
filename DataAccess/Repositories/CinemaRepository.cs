using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class CinemaRepository(CinemaContext context) : ICinemaRepository
{
    public async Task CreateAsync(Cinema cinema, CancellationToken cancellationToken)
    {
        await context.Cinemas.AddAsync(cinema, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Cinema>> GetCinemas()
    {
        return await context.Cinemas
            .AsQueryable()
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<List<Cinema>> GetCinemasWithDetails()
    {
        return await context.Cinemas
            .AsQueryable()
            .AsNoTracking()
            .Include(x => x.Details)
            .ToListAsync();
    }

    public async Task<Cinema> GetCinema(int id)
    {
        return await context.Cinemas
            .AsNoTracking()
            .FirstAsync(m => m.Id == id);
    }
    
    public async Task<Cinema> GetCinemaWithDetails(int id)
    {
        return await context.Cinemas
            .AsNoTracking()
            .Include(x => x.Details)
            .FirstAsync(m => m.Id == id);
    }

    public async Task DeleteCinema(Cinema cinema, CancellationToken cancellationToken)
    {
        var details = context.Details.FirstOrDefault(x => x.CinemaId == cinema.Id);
        if (details != null)
        {
            context.Details.Remove(details);
        }
        
        context.Cinemas.Remove(cinema);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateCinema(Cinema cinema, CancellationToken cancellationToken)
    {
        context.Cinemas.Update(cinema);
        await context.SaveChangesAsync(cancellationToken);
    }
}