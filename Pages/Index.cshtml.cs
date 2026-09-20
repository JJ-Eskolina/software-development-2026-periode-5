using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLitePCL;

namespace jj_eskolina_silver_enigma.Pages;


public class IndexModel : PageModel
{
    public int VehicleCount { get; private set; }
    public int ActiveReservations { get; private set; }
    public int VehiclesInMaintenance { get; private set; }
    public decimal OutstandingPayments { get; private set; }
    public List<Reservation> RecentReservations { get; private set; } = new List<Reservation>();
   
    private readonly BusverhuurContext _context;

    public IndexModel(BusverhuurContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        VehicleCount = _context.Vehicles.Count();
        VehiclesInMaintenance = _context.Vehicles.Count(v => v.Status == "In Onderhoud");
        ActiveReservations = _context.Reservations.Count(r => r.Status == "Bevestigd" || r.Status == "In Behandeling");
        OutstandingPayments = _context.Reservations.Count(r => !r.IsPaid) * 1_062.50m;
        
    }
}
