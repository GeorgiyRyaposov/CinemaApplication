using BusinessLogic.Services;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebCinemaApp.Pages;

public class CinemaDetails : PageModel
{
    [BindProperty]
    public Cinema Cinema { get; set; }
    
    private readonly ILogger<IndexModel> _logger;
    private readonly ICinemaService _cinemaService;

    public CinemaDetails(ILogger<IndexModel> logger, ICinemaService cinemaService)
    {
        _logger = logger;
        _cinemaService = cinemaService;
    }
    
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Cinema = await _cinemaService.GetCinemaWithDetails(id.GetValueOrDefault());

        return Page();
    }
}