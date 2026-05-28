using IShopping.Models;
using System;
using System.Collections.Generic;

namespace IShopping.Models
{
    public class Compra
    {
        // O EF deteta automaticamente como Chave Primária por se chamar Id
        public int Id { get; set; }
        public string Nome { get; set; }

        // Novo campo para os estados "PLANEADA", "EM COMPRA", "FECHADA"
        public string Estado { get; set; }

        // Como são DateTime normais (sem ?), são obrigatórios por natureza
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataFecho { get; set; }

        public bool EstaFechada { get; set; }

        // O EF associa automaticamente CriadoPorId à propriedade CriadoPor
        public int CriadoPorId { get; set; }
        public virtual Utilizador CriadoPor { get; set; }

        public int? AlteradoPorId { get; set; }
        public virtual Utilizador AlteradoPor { get; set; }

        public int? FechadoPorId { get; set; }
        public virtual Utilizador FechadoPor { get; set; }

        public virtual ICollection<ItemCompra> Itens { get; set; }
    }
}