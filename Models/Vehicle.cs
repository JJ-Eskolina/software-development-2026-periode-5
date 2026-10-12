using System.ComponentModel.DataAnnotations;

namespace jj_eskolina_silver_enigma.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Beschikbaar";

        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
        public string LastInspection { get; set; } = string.Empty;
        public bool HasDamage { get; set; }
        public string? Damage { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Seats { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty;

        public ICollection<VehicleImage> Images { get; set; } = new List<VehicleImage>();
    }
}