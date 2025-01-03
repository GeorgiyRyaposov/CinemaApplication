using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebCinemaApp.Pages;

public class CreateCinema : PageModel
{
    [BindProperty]
    public string Cinema { get; set; }
    
    private readonly ILogger<IndexModel> _logger;
    private readonly ICinemaService _cinemaService;

    public CreateCinema(ILogger<IndexModel> logger, ICinemaService cinemaService)
    {
        _logger = logger;
        _cinemaService = cinemaService;
    }
    
    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || string.IsNullOrEmpty(Cinema))
        {
            return Page();
        }

        await _cinemaService.CreateAsync(Cinema, CancellationToken.None);

        return RedirectToPage("./Index");
    }
}