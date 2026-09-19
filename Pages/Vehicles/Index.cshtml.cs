using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jj_eskolina_silver_enigma.Pages.Vehicles;

public class IndexModel : PageModel
{
    private readonly BusverhuurContext _context;
    public IndexModel(BusverhuurContext context)
    {
        _context = context;
    }

    public List<Vehicle> Vehicles { get; private set; } = [];

    public void OnGet()
    {
        Vehicles = _context.Vehicles.ToList();
    }
}
    