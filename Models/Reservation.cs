using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jj_eskolina_silver_enigma.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ReservationNumber { get; set; } = string.Empty;
        
        public string Status { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Foreign key to the Vehicle entity
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; } 
    }
}