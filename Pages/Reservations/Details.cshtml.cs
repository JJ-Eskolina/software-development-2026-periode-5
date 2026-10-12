using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace jj_eskolina_silver_enigma.Pages.Reservations;

public class DetailsModel : PageModel
{
    private readonly BusverhuurContext _context;

    public DetailsModel(BusverhuurContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Reservation Reservation { get; set; } = new();

    public List<SelectListItem> Vehicles { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var reservation = await _context.Reservations
            .AsNoTracking()
            .Include(item => item.Vehicle)
            .FirstOrDefaultAsync(item => item.Id == id);
        if (reservation is null)
        {
            return NotFound();
        }

        Reservation = reservation;
        await LoadVehiclesAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (id != Reservation.Id)
        {
            return BadRequest();
        }

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

        var storedReservation = await _context.Reservations.FindAsync(id);
        if (storedReservation is null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            Reservation.Vehicle = await _context.Vehicles
                .AsNoTracking()
                .FirstOrDefaultAsync(vehicle => vehicle.Id == Reservation.VehicleId);
            await LoadVehiclesAsync();
            return Page();
        }

        storedReservation.ReservationNumber = Reservation.ReservationNumber;
        storedReservation.CustomerName = Reservation.CustomerName;
        storedReservation.VehicleId = Reservation.VehicleId;
        storedReservation.StartDate = Reservation.StartDate;
        storedReservation.EndDate = Reservation.EndDate;
        storedReservation.Status = Reservation.Status;
        storedReservation.IsPaid = Reservation.IsPaid;
        storedReservation.StartMileage = Reservation.StartMileage;
        storedReservation.EndMileage = Reservation.EndMileage;
        storedReservation.TotalAmount = Reservation.TotalAmount;
        storedReservation.Notes = Reservation.Notes;

        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
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
