using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jj_eskolina_silver_enigma.Pages.Reservations;

public class DetailsModel : PageModel
{
    public ReservationViewModel Reservation { get; private set; } = new();

    public IActionResult OnGet(int id)
    {
        var reservation = MockData.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation is null)
        {
            return NotFound();
        }

        Reservation = reservation;
        return Page();
    }
}
