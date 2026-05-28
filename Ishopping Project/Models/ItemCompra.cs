using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Models
{
    public class ItemCompra
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Mantive o teu padrão "QuantidadeComprada"
        public int QuantidadeComprada { get; set; }
        public decimal PrecoUnitario { get; set; }

        // Campos vitais para os Requisitos 14, 15 e 17 do Modo Compra:
        public bool PreviaComprar { get; set; } // True = Previsto, False = Extra/Não previsto
        public bool Adquirido { get; set; }      // Se já foi feito o "check" no carrinho
        public string Observacoes { get; set; } // Observações dos extras

        // Ligação com o Artigo (Requisito 11 e 15)
        public int ArtigoId { get; set; }
        public virtual Artigo Artigo { get; set; }

        // Ligações de Auditoria e Compra
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