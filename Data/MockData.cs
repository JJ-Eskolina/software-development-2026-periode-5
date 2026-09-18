using jj_eskolina_silver_enigma.Models;

namespace jj_eskolina_silver_enigma.Data;

/// <summary>
/// Levert voorbeeldgegevens voor de website. Er is bewust geen database gekoppeld;
/// deze klasse simuleert alleen de inhoud zodat de interface getoond kan worden.
/// </summary>
public static class MockData
{
    public static List<VehicleViewModel> Vehicles { get; } =
    [
        new VehicleViewModel
        {
            Id = 1,
            Name = "Mercedes Sprinter 316",
            LicensePlate = "XX-123-YY",
            Type = "Minibus",
            Status = "Beschikbaar",
            ImageUrl = "https://images.unsplash.com/photo-1601584115197-04ecc0da31d7?auto=format&fit=crop&w=900&q=80",
            Mileage = 145230,
            LastInspection = "01-12-2024",
            Damage = "Geen schade",
            HasDamage = false,
            Year = 2019,
            Seats = "16+1",
            FuelType = "Diesel",
            GalleryImages =
            [
                "https://images.unsplash.com/photo-1502877338535-766e1452684a?auto=format&fit=crop&w=300&q=80",
                "https://images.unsplash.com/photo-1503376780353-7e6692767b70?auto=format&fit=crop&w=300&q=80",
                "https://images.unsplash.com/photo-1520340356584-f9917d1eea6f?auto=format&fit=crop&w=300&q=80",
            ],
            DamageHistory =
            [
                new VehicleDamageRecord { Date = "12-08-2024", Description = "Kras op achterbumper tijdens inparkeren", Severity = "Laag", Status = "Afgerond" },
                new VehicleDamageRecord { Date = "28-09-2024", Description = "Lichte barst in zijraam passagierszijde", Severity = "Medium", Status = "In Behandeling" },
            ],
        },
        new VehicleViewModel
        {
            Id = 2,
            Name = "VDL Citea SLF",
            LicensePlate = "AA-999-BB",
            Type = "Stadsbus",
            Status = "Verhuurd",
            ImageUrl = "https://images.unsplash.com/photo-1570125909232-eb263c188f7e?auto=format&fit=crop&w=900&q=80",
            Mileage = 310450,
            LastInspection = "15-11-2024",
            Damage = "Lichte kras rechterspiegel",
            HasDamage = true,
            Year = 2018,
            Seats = "80",
            FuelType = "Elektrisch",
        },
        new VehicleViewModel
        {
            Id = 3,
            Name = "MAN Lion's Coach L",
            LicensePlate = "NL-008-CK",
            Type = "Touringcar",
            Status = "Beschikbaar",
            ImageUrl = "https://images.unsplash.com/photo-1544620347-c4fd4a3d5957?auto=format&fit=crop&w=900&q=80",
            Mileage = 520100,
            LastInspection = "20-10-2024",
            Damage = "Geen schade",
            HasDamage = false,
            Year = 2020,
            Seats = "53",
            FuelType = "Diesel",
        },
        new VehicleViewModel
        {
            Id = 4,
            Name = "Iveco Daily Minibus",
            LicensePlate = "GG-456-HH",
            Type = "Minibus",
            Status = "In Onderhoud",
            ImageUrl = "https://images.unsplash.com/photo-1519003722824-194d4455a60c?auto=format&fit=crop&w=900&q=80",
            Mileage = 88900,
            LastInspection = "10-09-2024",
            Damage = "Deuk achterklep",
            HasDamage = true,
            Year = 2017,
            Seats = "16",
            FuelType = "Diesel",
        },
        new VehicleViewModel
        {
            Id = 5,
            Name = "Mercedes Tourismo",
            LicensePlate = "BB-777-CC",
            Type = "Touringcar",
            Status = "Verhuurd",
            ImageUrl = "https://images.unsplash.com/photo-1544829099-b9a0c07fad1a?auto=format&fit=crop&w=900&q=80",
            Mileage = 245000,
            LastInspection = "05-02-2025",
            Damage = "Geen schade",
            HasDamage = false,
            Year = 2021,
            Seats = "51",
            FuelType = "Diesel",
        },
        new VehicleViewModel
        {
            Id = 6,
            Name = "Scania Interlink",
            LicensePlate = "DD-888-EE",
            Type = "Stadsbus",
            Status = "Beschikbaar",
            ImageUrl = "https://images.unsplash.com/photo-1568605117036-5fe5e7bab0b7?auto=format&fit=crop&w=900&q=80",
            Mileage = 412300,
            LastInspection = "18-01-2025",
            Damage = "Geen schade",
            HasDamage = false,
            Year = 2019,
            Seats = "45",
            FuelType = "Diesel",
        },
    ];

    public static List<ReservationViewModel> Reservations { get; } =
    [
        new ReservationViewModel
        {
            Id = 1,
            ReservationNumber = "#RES-2024-0089",
            CustomerName = "Johannes de Jong",
            CustomerPhone = "+31 6 12345678",
            CustomerEmail = "johannes@dejongreizen.nl",
            VehicleName = "Mercedes Sprinter 316",
            VehicleType = "Minibus",
            StartDate = "12-10-2024",
            EndDate = "15-10-2024",
            Status = "Bevestigd",
            IsPaid = true,
            PaymentMethod = "iDEAL / Bankoverschrijving",
            PickupLocation = "Utrecht Centraal Station",
            Destination = "Keukenhof, Lisse",
            StartMileage = 145230,
            EstimatedDistance = 320,
            Notes = "Klant heeft gevraagd om een extra schone minibus wegens VIP gasten. Er is een flesje water gewenst voor de chauffeur.",
        },
        new ReservationViewModel { Id = 2, ReservationNumber = "#RES-2024-0090", CustomerName = "Annelies Bakker", VehicleName = "VDL Citea SLF", StartDate = "14-10-2024", EndDate = "14-10-2024", Status = "In Behandeling", IsPaid = false },
        new ReservationViewModel { Id = 3, ReservationNumber = "#RES-2024-0091", CustomerName = "Friesland Reizen", VehicleName = "MAN Lion's Coach L", StartDate = "18-10-2024", EndDate = "25-10-2024", Status = "Bevestigd", IsPaid = true },
        new ReservationViewModel { Id = 4, ReservationNumber = "#RES-2024-0092", CustomerName = "Bram van der Meer", VehicleName = "Iveco Daily Minibus", StartDate = "20-10-2024", EndDate = "22-10-2024", Status = "In Behandeling", IsPaid = false },
        new ReservationViewModel { Id = 5, ReservationNumber = "#RES-2024-0093", CustomerName = "Utrecht Events", VehicleName = "Mercedes Sprinter 316", StartDate = "01-11-2024", EndDate = "03-11-2024", Status = "Afgerond", IsPaid = true },
        new ReservationViewModel { Id = 6, ReservationNumber = "#RES-2024-0094", CustomerName = "Sophie Visser", VehicleName = "MAN Lion's Coach L", StartDate = "05-11-2024", EndDate = "06-11-2024", Status = "Geannuleerd", IsPaid = false },
        new ReservationViewModel { Id = 7, ReservationNumber = "#RES-2024-0095", CustomerName = "Daan Hendriks", VehicleName = "VDL Citea SLF", StartDate = "10-11-2024", EndDate = "12-11-2024", Status = "Bevestigd", IsPaid = true },
    ];
}
