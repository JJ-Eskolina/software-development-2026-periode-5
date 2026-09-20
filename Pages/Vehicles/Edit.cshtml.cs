using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jj_eskolina_silver_enigma.Pages.Vehicles;

public class EditModel : PageModel
{
     private readonly BusverhuurContext _context;

    public EditModel(BusverhuurContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Vehicle Vehicle { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle is null)
        {
            return NotFound();
        }

        Vehicle = vehicle;
        return Page();
    }
    public IActionResult OnPost()
    {
        var vehicleToUpdate = _context.Vehicles.FirstOrDefault(v => v.Id == Vehicle.Id);

        if (vehicleToUpdate is null)
        {
            return NotFound();
        }

        vehicleToUpdate.Name = Vehicle.Name;
        vehicleToUpdate.LicensePlate = Vehicle.LicensePlate;
        vehicleToUpdate.Type = Vehicle.Type;
        vehicleToUpdate.Year = Vehicle.Year;
        vehicleToUpdate.Seats = Vehicle.Seats;
        vehicleToUpdate.FuelType = Vehicle.FuelType;
        vehicleToUpdate.Mileage = Vehicle.Mileage;
        vehicleToUpdate.LastInspection = Vehicle.LastInspection;

        _context.SaveChanges();
        return RedirectToPage("Index");
    }
    public IActionResult OnPostDelete(int id)
{
    var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id);
    if (vehicle is not null)
    {
        _context.Vehicles.Remove(vehicle);
        _context.SaveChanges();
    }

    return RedirectToPage();
}
}
