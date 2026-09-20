using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jj_eskolina_silver_enigma.Pages.Vehicles;

public class DetailsModel : PageModel
{
    private readonly BusverhuurContext _context;
    public Vehicle Vehicle { get; private set; } = new();

    public DetailsModel(BusverhuurContext context)
    {
        _context = context;
    }


    public IActionResult OnGet(int id)
    {
        var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle is null)
        {
            return NotFound();
        }

        Vehicle = vehicle;
        return Page();
    }
}
