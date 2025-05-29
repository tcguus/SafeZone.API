using System.ComponentModel.DataAnnotations;

namespace SafeZone.API.Models
{
    public class Alerta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        public string NivelGravidade { get; set; } = "Moderado";

        public DateTime DataHora { get; set; } = DateTime.Now;

        public int ZonaDeRiscoId { get; set; }
        public ZonaDeRisco? ZonaDeRisco { get; set; }
    }
}