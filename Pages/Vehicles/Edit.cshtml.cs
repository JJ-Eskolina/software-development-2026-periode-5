using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jj_eskolina_silver_enigma.Pages.Vehicles;

public class EditModel : PageModel
{
    public VehicleViewModel Vehicle { get; private set; } = new();

    public IActionResult OnGet(int id)
    {
        var vehicle = MockData.Vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle is null)
        {
            return NotFound();
        }

        Vehicle = vehicle;
        return Page();
    }
}
