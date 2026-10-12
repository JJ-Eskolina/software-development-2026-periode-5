using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace jj_eskolina_silver_enigma.Pages.Reservations;

public class IndexModel : PageModel
{

    private readonly BusverhuurContext _context;

    public IndexModel(BusverhuurContext context)
    {
        _context = context;
    }
    public List<Reservation> Reservations { get; private set; } = [];
    public decimal OutstandingPayments { get; private set; }

    public async Task OnGetAsync()
    {
        Reservations = await _context.Reservations
            .AsNoTracking()
            .Include(reservation => reservation.Vehicle)
            .OrderByDescending(reservation => reservation.StartDate)
            .ToListAsync();
        OutstandingPayments = Reservations
            .Where(reservation => !reservation.IsPaid)
            .Sum(reservation => reservation.TotalAmount);
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation is null)
        {
            return NotFound();
        }

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }
}
