using BusinessLogic.Services;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebCinemaApp.Pages;

public class IndexModel : PageModel
{
    public List<Cinema> Cinemas { get; set; }
    
    private readonly ILogger<IndexModel> _logger;
    private readonly ICinemaService _cinemaService;

    public IndexModel(ILogger<IndexModel> logger, ICinemaService cinemaService)
    {
        _logger = logger;
        _cinemaService = cinemaService;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var cinemas = await _cinemaService.GetCinemas();

        Cinemas = cinemas;

        return Page();
    }
}