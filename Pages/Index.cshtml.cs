using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

    public async Task OnGetAsync()
    {
        VehicleCount = await _context.Vehicles.CountAsync();
        VehiclesInMaintenance = await _context.Vehicles.CountAsync(v => v.Status == "In Onderhoud");
        ActiveReservations = await _context.Reservations.CountAsync(
            r => r.Status == "Bevestigd" || r.Status == "In Behandeling");
        OutstandingPayments = await _context.Reservations
            .Where(r => !r.IsPaid)
            .SumAsync(r => (decimal?)r.TotalAmount) ?? 0m;
        RecentReservations = await _context.Reservations
            .Include(r => r.Vehicle)
            .OrderByDescending(r => r.Id)
            .Take(5)
            .ToListAsync();
    }
}
