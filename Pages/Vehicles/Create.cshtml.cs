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
    public Vehicle NewVehicle { get; set; } = new Vehicle();
    public void OnGet() { }
    public IActionResult OnPost()
    {
        _context.Vehicles.Add(NewVehicle);
        _context.SaveChanges();
        return RedirectToPage("Index");
    }
}
    