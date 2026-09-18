namespace jj_eskolina_silver_enigma.Models;

/// <summary>Weergavemodel voor een voertuig. Bevat alleen voorbeeldgegevens (geen database).</summary>
public class VehicleViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LicensePlate { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Mileage { get; set; }
    public string LastInspection { get; set; } = string.Empty;
    public string Damage { get; set; } = string.Empty;
    public bool HasDamage { get; set; }
    public int Year { get; set; }
    public string Seats { get; set; } = string.Empty;
    public string FuelType { get; set; } = string.Empty;
    public List<string> GalleryImages { get; set; } = [];
    public List<VehicleDamageRecord> DamageHistory { get; set; } = [];
}

public class VehicleDamageRecord
{
    public string Date { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
