using Common.Models;

namespace Common.Infrastructure.Services;

public interface IMovieInfoService
{
    Task<Details> FindDetails(string name);
}