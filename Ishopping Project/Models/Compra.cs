using IShopping.Models;
using System;
using System.Collections.Generic;

namespace IShopping.Models
{
    public class Compra
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Estado { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataFecho { get; set; }

        public bool EstaFechada { get; set; }

        public int CriadoPorId { get; set; }
        public virtual Utilizador CriadoPor { get; set; }

        public int? AlteradoPorId { get; set; }
        public virtual Utilizador AlteradoPor { get; set; }

        public int? FechadoPorId { get; set; }
        public virtual Utilizador FechadoPor { get; set; }

        public virtual ICollection<ItemCompra> Itens { get; set; }
    }
}