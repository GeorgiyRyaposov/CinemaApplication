using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApplication.Controllers;

[ApiController]
[Route("Cinema")]
public class CinemaController : ControllerBase
{
    private readonly ICinemaService _cinemaService;

    public CinemaController(ICinemaService cinemaService)
    {
        _cinemaService = cinemaService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(string cinemaName)
    {
        await _cinemaService.CreateAsync(cinemaName, CancellationToken.None);
        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCinemas()
    {
        var result = await _cinemaService.GetCinemas();
        return Ok(result);
    }
}