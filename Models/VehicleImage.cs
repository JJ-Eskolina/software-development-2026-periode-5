using System.ComponentModel.DataAnnotations;

namespace jj_eskolina_silver_enigma.Models;

public class VehicleImage
{
    public int Id { get; set; }

    public int VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }

    [Required]
    [StringLength(255)]
    public string FileName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string ContentType { get; set; } = string.Empty;

    [Required]
    public byte[] Data { get; set; } = [];

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}
