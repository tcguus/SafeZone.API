using System.ComponentModel.DataAnnotations;

namespace SafeZone.API.Models
{
    public class Morador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 11 dígitos numéricos")]
        public string CPF { get; set; } = string.Empty;

        [Required]
        public string Prioridade { get; set; } = "Normal";

        public int ZonaDeRiscoId { get; set; }
        public ZonaDeRisco? ZonaDeRisco { get; set; }
    }
}