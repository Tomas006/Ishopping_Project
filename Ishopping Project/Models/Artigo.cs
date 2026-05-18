using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Models
{
    public class Artigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoArtigoId { get; set; }
        public virtual TipoArtigo TipoArtigo { get; set; }

    } 
}
