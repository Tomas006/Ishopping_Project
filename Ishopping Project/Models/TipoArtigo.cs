using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Models
{
    public class TipoArtigo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Artigo> Artigos { get; set; }


    }
}
