using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace jj_eskolina_silver_enigma.Pages.Vehicles;

public class IndexModel : PageModel
{
    private readonly BusverhuurContext _context;
    public IndexModel(BusverhuurContext context)
    {
        _context = context;
    }

    public List<Vehicle> Vehicles { get; private set; } = [];
    public Dictionary<int, int> PrimaryImageIds { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Vehicles = await _context.Vehicles.AsNoTracking().ToListAsync();
        PrimaryImageIds = await _context.VehicleImages
            .AsNoTracking()
            .GroupBy(image => image.VehicleId)
            .Select(group => new { VehicleId = group.Key, ImageId = group.Min(image => image.Id) })
            .ToDictionaryAsync(item => item.VehicleId, item => item.ImageId);
    }

    public async Task<IActionResult> OnGetImageAsync(int id, int? imageId)
    {
        var imageQuery = _context.VehicleImages.AsNoTracking().Where(image => image.VehicleId == id);
        if (imageId.HasValue)
        {
            imageQuery = imageQuery.Where(image => image.Id == imageId.Value);
        }
        else
        {
            imageQuery = imageQuery.OrderBy(image => image.Id);
        }

        var image = await imageQuery
            .Select(item => new { item.Data, item.ContentType })
            .FirstOrDefaultAsync();

        return image is null ? NotFound() : File(image.Data, image.ContentType);
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle is null)
        {
            return NotFound();
        }

        if (await _context.Reservations.AnyAsync(reservation => reservation.VehicleId == id))
        {
            TempData["ErrorMessage"] = "Dit voertuig heeft reserveringen en kan daarom niet worden verwijderd.";
            return RedirectToPage();
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }
}
    