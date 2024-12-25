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
        var cinema = new Cinema
        {
            Name = cinemaName,
        };

        await _cinemaRepository.CreateAsync(cinema, cancellationToken);
    }

    public async Task<List<string>> GetCinemas()
    {
        return await _cinemaRepository.GetCinemas();
    }
}