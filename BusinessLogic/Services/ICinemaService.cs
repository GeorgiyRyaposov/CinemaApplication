using DataAccess.Models;

namespace BusinessLogic.Services;

public interface ICinemaService
{
    Task CreateAsync(string cinemaName, CancellationToken cancellationToken);
    Task<List<Cinema>> GetCinemas();
}