using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Models
{
    public class ItemCompra
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeComprada { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int CriadoPorId { get; set; }
        public virtual Utilizador CriadoPor { get; set; }
        public int? AlteradoPorId { get; set; }
        public virtual Utilizador AlteradoPor { get; set; }
        public int CompraId { get; set; }
        public virtual Compra Compra { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}
