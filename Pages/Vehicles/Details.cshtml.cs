using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace jj_eskolina_silver_enigma.Pages.Vehicles;

public class DetailsModel : PageModel
{
    private readonly BusverhuurContext _context;
    public Vehicle Vehicle { get; private set; } = new();
    public bool HasStoredImage { get; private set; }

    public DetailsModel(BusverhuurContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> OnGetAsync(int id)
    {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        if (vehicle is null)
        {
            return NotFound();
        }

        Vehicle = vehicle;
        HasStoredImage = await _context.VehicleImages.AnyAsync(image => image.VehicleId == id);
        return Page();
    }
}
