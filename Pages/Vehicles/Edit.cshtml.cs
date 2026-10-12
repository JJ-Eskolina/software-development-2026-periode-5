using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

    [BindProperty]
    public List<IFormFile>? UploadedImages { get; set; }

    public List<VehicleImage> Images { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle is null)
        {
            return NotFound();
        }

        Vehicle = vehicle;
        await LoadImagesAsync(id);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (id != Vehicle.Id)
        {
            return BadRequest();
        }

        var vehicleToUpdate = await _context.Vehicles.FindAsync(id);
        if (vehicleToUpdate is null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            await LoadImagesAsync(id);
            return Page();
        }

        vehicleToUpdate.Name = Vehicle.Name;
        vehicleToUpdate.LicensePlate = Vehicle.LicensePlate;
        vehicleToUpdate.Type = Vehicle.Type;
        vehicleToUpdate.Status = Vehicle.Status;
        vehicleToUpdate.Year = Vehicle.Year;
        vehicleToUpdate.Seats = Vehicle.Seats;
        vehicleToUpdate.FuelType = Vehicle.FuelType;
        vehicleToUpdate.Mileage = Vehicle.Mileage;
        vehicleToUpdate.LastInspection = Vehicle.LastInspection;
        vehicleToUpdate.HasDamage = Vehicle.HasDamage;
        vehicleToUpdate.Damage = Vehicle.Damage;

        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }

    public async Task<IActionResult> OnPostUploadImagesAsync(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle is null)
        {
            return NotFound();
        }

        Vehicle = vehicle;
        var (images, imageError) = await VehicleImageUpload.ReadAsync(UploadedImages ?? []);
        if (imageError is not null || images.Count == 0)
        {
            ModelState.Clear();
            ModelState.AddModelError(
                nameof(UploadedImages),
                imageError ?? "Selecteer ten minste één afbeelding.");
            await LoadImagesAsync(id);
            return Page();
        }

        foreach (var image in images)
        {
            image.VehicleId = id;
            _context.VehicleImages.Add(image);
        }

        await _context.SaveChangesAsync();
        return RedirectToPage(new { id });
    }

    public async Task<IActionResult> OnPostDeleteImageAsync(int id, int imageId)
    {
        var image = await _context.VehicleImages
            .FirstOrDefaultAsync(item => item.Id == imageId && item.VehicleId == id);
        if (image is null)
        {
            return NotFound();
        }

        _context.VehicleImages.Remove(image);
        await _context.SaveChangesAsync();
        return RedirectToPage(new { id });
    }

    private async Task LoadImagesAsync(int vehicleId)
    {
        Images = await _context.VehicleImages
            .AsNoTracking()
            .Where(image => image.VehicleId == vehicleId)
            .OrderBy(image => image.Id)
            .Select(image => new VehicleImage
            {
                Id = image.Id,
                VehicleId = image.VehicleId,
                FileName = image.FileName,
                ContentType = image.ContentType
            })
            .ToListAsync();
    }
}
