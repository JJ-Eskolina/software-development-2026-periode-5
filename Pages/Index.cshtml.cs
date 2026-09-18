using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jj_eskolina_silver_enigma.Pages;

public class IndexModel : PageModel
{
    public int VehicleCount { get; private set; }
    public int ActiveReservations { get; private set; }
    public int VehiclesInMaintenance { get; private set; }
    public decimal OutstandingPayments { get; private set; }
    public List<ReservationViewModel> RecentReservations { get; private set; } = [];

    public void OnGet()
    {
        VehicleCount = MockData.Vehicles.Count;
        VehiclesInMaintenance = MockData.Vehicles.Count(v => v.Status == "In Onderhoud");
        ActiveReservations = MockData.Reservations.Count(r => r.Status is "Bevestigd" or "In Behandeling");
        OutstandingPayments = MockData.Reservations.Count(r => !r.IsPaid) * 1_062.50m;
        RecentReservations = MockData.Reservations.Take(5).ToList();
    }
}
