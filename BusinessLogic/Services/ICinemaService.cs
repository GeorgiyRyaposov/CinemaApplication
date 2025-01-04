using Common.Models;

namespace BusinessLogic.Services;

public interface ICinemaService
{
    Task CreateAsync(string cinemaName, CancellationToken cancellationToken);
    Task<List<Cinema>> GetCinemas();
    Task<Cinema> GetCinema(int id);
    
    Task DeleteCinema(int id, CancellationToken cancellationToken);
}