using System.Net.Http.Headers;
using Common.Infrastructure.Services;
using Common.Models;
using KinopoiskApi.Models;

namespace KinopoiskApi;

public class KinopoiskService : IMovieInfoService
{
    private const string API_URL = "https://api.kinopoisk.dev/v1.4/";

    public async Task<Details> FindDetails(string name)
    {
        using var client = GetClient();
        var response = await client.GetAsync(new Uri(API_URL + $"movie/search?page=1&limit=10&query={name}"));
        if (!response.IsSuccessStatusCode)
        {
            return null!;
        }
        
        var result = await response.Content.ReadAsAsync<Root>();
        return ConvertToDetails(result);
    }

    private Details ConvertToDetails(Root? root)
    {
        var doc = root?.Docs.FirstOrDefault();
        if (doc == null)
        {
            return null!;
        }
        
        return new Details
        {
            AlternativeName = doc.AlternativeName,
            Year = doc.Year,
            Description = doc.Description,
            ShortDescription = doc.ShortDescription,
            
            IsSeries = doc.IsSeries,
            Length = doc.IsSeries 
                ? doc.SeriesLength.GetValueOrDefault() 
                : doc.MovieLength.GetValueOrDefault(),
            
            Genres = doc.Genres.Select(x => x.Name).ToArray(),
            Countries = doc.Countries.Select(x => x.Name).ToArray(),
            
            LogoUrl = doc.Poster.Url,
            PreviewUrl = doc.Poster.PreviewUrl,
            
            RatingImdb = doc.Rating.Imdb,
            RatingKP = doc.Rating.Kp,
        };
    }
    
    private HttpClient GetClient()
    {
        var key = Environment.GetEnvironmentVariable("X-API-KEY", EnvironmentVariableTarget.User);
        
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-API-KEY", key);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        return client;
    }
}