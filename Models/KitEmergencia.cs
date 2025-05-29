using System.ComponentModel.DataAnnotations;

public class KitEmergencia
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)] // SQLite aceita apenas tamanhos fixos
    public string Tipo { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [MaxLength(200)]
    public string? LocalEstoque { get; set; }
}