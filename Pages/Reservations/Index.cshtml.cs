using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jj_eskolina_silver_enigma.Pages.Reservations;

public class IndexModel : PageModel
{
    public List<ReservationViewModel> Reservations { get; private set; } = [];
    public int Total { get; private set; }
    public int Active { get; private set; }
    public int UpcomingWeek { get; private set; } = 12;
    public decimal OutstandingPayments { get; private set; }

    public void OnGet()
    {
        Reservations = MockData.Reservations;
        Total = 148;
        Active = 23;
        OutstandingPayments = 4250;
    }
}
