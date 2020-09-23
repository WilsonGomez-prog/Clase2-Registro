using System.ComponentModel.DataAnnotations;

namespace Clase2_Registro.Entidades
{
    public class Actores
{
    [Key]
    public int ActorId { get; set; }
    public string Nombres { get; set; }
    public decimal Salario { get; set; }
}
}