using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jj_eskolina_silver_enigma.Pages.Vehicles;

public class IndexModel : PageModel
{
    public List<VehicleViewModel> Vehicles { get; private set; } = [];

    public void OnGet()
    {
        Vehicles = MockData.Vehicles;
    }
}
