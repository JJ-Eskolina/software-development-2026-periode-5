using System.ComponentModel.DataAnnotations;

namespace jj_eskolina_silver_enigma.Models
{
    public class Reservation
    {
        public static readonly string[] StatusOptions =
        [
            "Bevestigd",
            "In Behandeling",
            "Afgerond",
            "Geannuleerd"
        ];

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string ReservationNumber { get; set; } = string.Empty;
        
        [Required]
        public string Status { get; set; } = string.Empty;
        public bool IsPaid { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Range(0, int.MaxValue)]
        public int StartMileage { get; set; }

        [Range(0, int.MaxValue)]
        public int? EndMileage { get; set; }

        [Range(0, 10000000)]
        public decimal TotalAmount { get; set; }

        public string Notes { get; set; } = string.Empty;

        // Foreign key to the Vehicle entity
        [Range(1, int.MaxValue)]
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; } 
    }
}