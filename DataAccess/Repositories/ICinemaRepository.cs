﻿using DataAccess.Models;

namespace DataAccess.Repositories;

public interface ICinemaRepository
{
    Task CreateAsync(Cinema cinema, CancellationToken cancellationToken);
    Task<List<string>> GetCinemas();
}