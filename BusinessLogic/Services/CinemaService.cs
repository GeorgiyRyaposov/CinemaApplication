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

    public async Task<Cinema> GetCinema(int id)
    {
        return await _cinemaRepository.GetCinema(id);
    }

    public async Task<List<Cinema>> GetCinemas()
    {
        return await _cinemaRepository.GetCinemas();
    }

    public async Task DeleteCinema(int id, CancellationToken cancellationToken)
    {
        var cinema = await _cinemaRepository.GetCinema(id);
        if (cinema == null)
        {
            throw new ArgumentNullException(nameof(cinema));
        }
        
        await _cinemaRepository.DeleteCinema(cinema, cancellationToken);
    }
}