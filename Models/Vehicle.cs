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
    }
}