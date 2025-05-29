namespace SafeZone.API.DTOs
{
    public class AlertaDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string NivelGravidade { get; set; } // Leve, Moderado, Crítico
        public DateTime DataHora { get; set; }
        public int ZonaDeRiscoId { get; set; }
    }
}