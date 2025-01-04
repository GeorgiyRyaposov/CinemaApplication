using DataAccess.Models;

namespace DataAccess.Repositories;

public interface ICinemaRepository
{
    Task CreateAsync(Cinema cinema, CancellationToken cancellationToken);
    Task<List<Cinema>> GetCinemas();
    Task<Cinema> GetCinema(int id);

    Task DeleteCinema(Cinema cinema, CancellationToken cancellationToken);
}