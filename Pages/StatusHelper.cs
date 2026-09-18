namespace jj_eskolina_silver_enigma.Pages;

/// <summary>Bepaalt welke badge-kleur bij een status hoort in de Razor Pages weergaven.</summary>
public static class StatusHelper
{
    public static string CssClass(string status) => status switch
    {
        "Beschikbaar" or "Bevestigd" or "Betaald" => "badge-green",
        "Verhuurd" or "In Behandeling" => "badge-amber",
        "In Onderhoud" or "Geannuleerd" => "badge-red",
        "Afgerond" => "badge-gray",
        _ => "badge-gray",
    };
}
