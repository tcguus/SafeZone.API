using System.Text.Json.Serialization;

public class ZonaDeRiscoDTO
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; }

    [JsonPropertyName("tipoEvento")]
    public string TipoEvento { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = "Ativo";

    [JsonPropertyName("coordenadas")]
    public string? Coordenadas { get; set; }
}