using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Models
{
    public class Orcamento
    {
        public int Id { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public decimal ValorMaximo { get; set; }
        public int CriadoPorId { get; set; }
        public virtual Utilizador CriadoPor { get; set; }
        public int? AlteradoPorId { get; set; }
        public virtual Utilizador AlteradoPor { get; set; }
    }
}
