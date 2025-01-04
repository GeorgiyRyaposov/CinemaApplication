using Common.Infrastructure.Services;
using Common.Models;
using DataAccess.Repositories;

namespace BusinessLogic.Services;

public class CinemaService : ICinemaService
{
    private readonly ICinemaRepository _cinemaRepository;
    private readonly IMovieInfoService _movieInfoService;

    public CinemaService(ICinemaRepository cinemaRepository, IMovieInfoService movieInfoService)
    {
        _cinemaRepository = cinemaRepository;
        _movieInfoService = movieInfoService;
    }

    public async Task CreateAsync(string cinemaName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(cinemaName))
        {
            throw new ArgumentNullException(nameof(cinemaName));
        }
        
        var cinemas = await _cinemaRepository.GetCinemas();
        if (cinemas.Any(x => string.Equals(cinemaName, x.Name, StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(cinemaName, x.Details?.AlternativeName, StringComparison.OrdinalIgnoreCase)))
        {
            //already exists
            return;
        }
        
        var details = await _movieInfoService.FindDetails(cinemaName);
        
        var cinema = new Cinema
        {
            Name = cinemaName,
            Details = details,
        };

        await _cinemaRepository.CreateAsync(cinema, cancellationToken);
    }

    public async Task<Cinema> GetCinema(int id)
    {
        return await _cinemaRepository.GetCinema(id);
    }
    
    public async Task<Cinema> GetCinemaWithDetails(int id)
    {
        return await _cinemaRepository.GetCinemaWithDetails(id);
    }

    public async Task<List<Cinema>> GetCinemasWithDetails()
    {
        return await _cinemaRepository.GetCinemasWithDetails();
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

    public async Task MarkAsWatched(int id, CancellationToken cancellationToken)
    {
        var cinema = await _cinemaRepository.GetCinema(id);
        if (cinema.Watched)
        {
            return;
        }
        
        cinema.Watched = true;
        await _cinemaRepository.UpdateCinema(cinema, cancellationToken);
    }
}