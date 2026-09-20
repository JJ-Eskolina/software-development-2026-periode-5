using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jj_eskolina_silver_enigma.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Mileage { get; set; }


        public string ImageUrl { get; set; } = string.Empty;
        public string LastInspection { get; set; } = string.Empty;
        public bool HasDamage { get; set; }
        public string Damage { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Seats { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty;
    }
}