using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebCinemaApp.Pages;

public class DeleteCinema : PageModel
{    
    [BindProperty]
    public Cinema Cinema { get; set; }
    
    private readonly ILogger<IndexModel> _logger;
    private readonly ICinemaService _cinemaService;

    public DeleteCinema(ILogger<IndexModel> logger, ICinemaService cinemaService)
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

        Cinema = await _cinemaService.GetCinema(id.GetValueOrDefault());
        if (Cinema == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        await _cinemaService.DeleteCinema(id.GetValueOrDefault(), CancellationToken.None);

        return RedirectToPage("./Index");
    }
}