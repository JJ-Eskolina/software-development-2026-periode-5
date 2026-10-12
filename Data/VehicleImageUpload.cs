using jj_eskolina_silver_enigma.Models;
using Microsoft.AspNetCore.Http;

namespace jj_eskolina_silver_enigma.Data;

public static class VehicleImageUpload
{
    public const int MaximumFileSize = 5 * 1024 * 1024;
    public const int MaximumFiles = 5;

    public static async Task<(List<VehicleImage> Images, string? Error)> ReadAsync(
        IEnumerable<IFormFile> files)
    {
        var selectedFiles = files.Where(file => file.Length > 0).ToList();
        if (selectedFiles.Count == 0)
        {
            return ([], null);
        }

        if (selectedFiles.Count > MaximumFiles)
        {
            return ([], $"Je kunt maximaal {MaximumFiles} afbeeldingen tegelijk uploaden.");
        }

        var images = new List<VehicleImage>();
        foreach (var file in selectedFiles)
        {
            if (file.Length > MaximumFileSize)
            {
                return ([], $"{Path.GetFileName(file.FileName)} is groter dan 5 MB.");
            }

            await using var input = file.OpenReadStream();
            using var output = new MemoryStream();
            await input.CopyToAsync(output);
            var data = output.ToArray();
            var contentType = GetContentType(data);
            if (contentType is null)
            {
                return ([], $"{Path.GetFileName(file.FileName)} is geen ondersteunde JPG-, PNG-, GIF- of WebP-afbeelding.");
            }

            images.Add(new VehicleImage
            {
                FileName = Path.GetFileName(file.FileName),
                ContentType = contentType,
                Data = data
            });
        }

        return (images, null);
    }

    private static string? GetContentType(byte[] data)
    {
        if (data.Length >= 3 && data[0] == 0xFF && data[1] == 0xD8 && data[2] == 0xFF)
        {
            return "image/jpeg";
        }

        if (data.Length >= 8 &&
            data[0] == 0x89 && data[1] == 0x50 && data[2] == 0x4E && data[3] == 0x47 &&
            data[4] == 0x0D && data[5] == 0x0A && data[6] == 0x1A && data[7] == 0x0A)
        {
            return "image/png";
        }

        if (data.Length >= 6 &&
            (System.Text.Encoding.ASCII.GetString(data, 0, 6) is "GIF87a" or "GIF89a"))
        {
            return "image/gif";
        }

        if (data.Length >= 12 &&
            System.Text.Encoding.ASCII.GetString(data, 0, 4) == "RIFF" &&
            System.Text.Encoding.ASCII.GetString(data, 8, 4) == "WEBP")
        {
            return "image/webp";
        }

        return null;
    }
}
