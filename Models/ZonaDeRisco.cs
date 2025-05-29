using System.ComponentModel.DataAnnotations;

namespace SafeZone.API.Models
{
    public class ZonaDeRisco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string TipoEvento { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Ativo";

        public string? Coordenadas { get; set; }

        public List<Alerta> Alertas { get; set; } = new();
        public List<Morador> Moradores { get; set; } = new();
    }
}