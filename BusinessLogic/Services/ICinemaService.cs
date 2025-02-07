﻿using Common.Models;

namespace BusinessLogic.Services;

public interface ICinemaService
{
    Task CreateAsync(string cinemaName, CancellationToken cancellationToken);
    Task<List<Cinema>> GetCinemasWithDetails();
    Task<Cinema> GetCinema(int id);
    Task<Cinema> GetCinemaWithDetails(int id);
    
    Task DeleteCinema(int id, CancellationToken cancellationToken);
    Task MarkAsWatched(int id, CancellationToken cancellationToken);
}