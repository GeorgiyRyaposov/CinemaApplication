using Common.Models;

namespace DataAccess.Repositories;

public interface ICinemaRepository
{
    Task CreateAsync(Cinema cinema, CancellationToken cancellationToken);
    Task<List<Cinema>> GetCinemas();
    Task<List<Cinema>> GetCinemasWithDetails();
    Task<Cinema> GetCinema(int id);
    Task<Cinema> GetCinemaWithDetails(int id);

    Task UpdateCinema(Cinema cinema, CancellationToken cancellationToken);
    
    Task DeleteCinema(Cinema cinema, CancellationToken cancellationToken);
}