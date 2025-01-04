using DataAccess.Models;
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

    public async Task<Cinema> GetCinema(int id)
    {
        return await context.Cinemas
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task DeleteCinema(Cinema cinema, CancellationToken cancellationToken)
    {
        context.Cinemas.Remove(cinema);
        await context.SaveChangesAsync(cancellationToken);
    }
}