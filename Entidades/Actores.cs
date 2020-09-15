using System.ComponentModel.DataAnnotations;

public class Actores
{
    [Key]
    public int ActorId { get; set; }
    public string Nombres { get; set; }
    public decimal Salario { get; set; }
}