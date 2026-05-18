using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Models
{
    public class ItemPrevisto : ItemCompra
    {
        public int ArtigoId { get; set; }
        public virtual Artigo Artigo { get; set; }
        public int QuantidadePrevista { get; set; }
    }
}
