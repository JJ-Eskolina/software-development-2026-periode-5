namespace jj_eskolina_silver_enigma.Models;

/// <summary>Weergavemodel voor een reservering. Bevat alleen voorbeeldgegevens (geen database).</summary>
public class ReservationViewModel
{
    public int Id { get; set; }
    public string ReservationNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string VehicleName { get; set; } = string.Empty;
    public string VehicleType { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool IsPaid { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string PickupLocation { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public int StartMileage { get; set; }
    public int? EndMileage { get; set; }
    public int EstimatedDistance { get; set; }
    public string Notes { get; set; } = string.Empty;
}
