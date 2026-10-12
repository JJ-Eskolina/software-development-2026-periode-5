using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace jj_eskolina_silver_enigma.Pages.Reservations;

public class CreateModel : PageModel
{
    private readonly BusverhuurContext _context;

    public CreateModel(BusverhuurContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Reservation Reservation { get; set; } = new()
    {
        ReservationNumber = $"RES-{DateTime.UtcNow:yyyyMMddHHmmss}",
        StartDate = DateTime.Today,
        EndDate = DateTime.Today.AddDays(1),
        Status = "In Behandeling"
    };

    public List<SelectListItem> Vehicles { get; private set; } = [];

    public async Task OnGetAsync()
    {
        await LoadVehiclesAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Reservation.EndDate < Reservation.StartDate)
        {
            ModelState.AddModelError("Reservation.EndDate", "De einddatum mag niet vóór de startdatum liggen.");
        }

        if (Reservation.EndMileage.HasValue && Reservation.EndMileage < Reservation.StartMileage)
        {
            ModelState.AddModelError("Reservation.EndMileage", "De eindkilometerstand mag niet lager zijn dan de beginkilometerstand.");
        }

        if (!Reservation.StatusOptions.Contains(Reservation.Status))
        {
            ModelState.AddModelError("Reservation.Status", "Kies een geldige reserveringsstatus.");
        }

        if (!await _context.Vehicles.AnyAsync(vehicle => vehicle.Id == Reservation.VehicleId))
        {
            ModelState.AddModelError("Reservation.VehicleId", "Kies een bestaand voertuig.");
        }

        if (!ModelState.IsValid)
        {
            await LoadVehiclesAsync();
            return Page();
        }

        _context.Reservations.Add(Reservation);
        await _context.SaveChangesAsync();
        return RedirectToPage("Details", new { id = Reservation.Id });
    }

    private async Task LoadVehiclesAsync()
    {
        Vehicles = await _context.Vehicles
            .AsNoTracking()
            .OrderBy(vehicle => vehicle.Name)
            .Select(vehicle => new SelectListItem
            {
                Value = vehicle.Id.ToString(),
                Text = $"{vehicle.Name} ({vehicle.LicensePlate})"
            })
            .ToListAsync();
    }
}
