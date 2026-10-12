using jj_eskolina_silver_enigma.Data;
using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jj_eskolina_silver_enigma.Pages.Vehicles;

public class CreateModel : PageModel
{
    private readonly BusverhuurContext _context;

    public CreateModel(BusverhuurContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Vehicle NewVehicle { get; set; } = new();

    [BindProperty]
    public List<IFormFile>? Images { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var (images, imageError) = await VehicleImageUpload.ReadAsync(Images ?? []);
        if (imageError is not null)
        {
            ModelState.AddModelError(nameof(Images), imageError);
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        NewVehicle.Images = images;
        _context.Vehicles.Add(NewVehicle);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}