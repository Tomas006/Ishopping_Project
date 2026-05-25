using IShopping.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Orcamento
{
    public int Id { get; set; } 
    public int Mes { get; set; }
    public int Ano { get; set; }
    public decimal ValorMaximo { get; set; }

    public int CriadoPorId { get; set; }
    [ForeignKey("CriadoPorId")] 
    public virtual Utilizador CriadoPor { get; set; }

    public int? AlteradoPorId { get; set; }
    [ForeignKey("AlteradoPorId")] 
    public virtual Utilizador AlteradoPor { get; set; }
}