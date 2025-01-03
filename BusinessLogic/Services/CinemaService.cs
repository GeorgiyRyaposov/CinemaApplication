using DataAccess.Models;
using DataAccess.Repositories;

namespace BusinessLogic.Services;

public class CinemaService : ICinemaService
{
    private readonly ICinemaRepository _cinemaRepository;

    public CinemaService(ICinemaRepository cinemaRepository)
    {
        _cinemaRepository = cinemaRepository;
    }

    public async Task CreateAsync(string cinemaName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(cinemaName))
        {
            throw new ArgumentNullException(nameof(cinemaName));
        }
        
        var cinema = new Cinema
        {
            Name = cinemaName,
        };

        await _cinemaRepository.CreateAsync(cinema, cancellationToken);
    }

    public async Task<List<Cinema>> GetCinemas()
    {
        return await _cinemaRepository.GetCinemas();
    }
}