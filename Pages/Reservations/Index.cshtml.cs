using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jj_eskolina_silver_enigma.Pages.Reservations;

public class IndexModel : PageModel
{

    private readonly BusverhuurContext _context;

    public IndexModel(BusverhuurContext context)
    {
        _context = context;
    }
    public List<Reservation> Reservations { get; private set; } = [];
    public void OnGet()
    {
        Reservations = _context.Reservations.ToList();
    }
}
