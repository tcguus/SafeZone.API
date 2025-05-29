namespace SafeZone.API.DTOs
{
    public class MoradorDTO
    {
        public string Nome { get; set; }
        public string CPF { get; set; } 
        public string Prioridade { get; set; } // Alta, Média, Normal
        public int ZonaDeRiscoId { get; set; }
    }
}