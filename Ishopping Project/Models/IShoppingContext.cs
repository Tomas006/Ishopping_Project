using IShopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Models
{
    internal class IShoppingContext : DbContext
    {
        public IShoppingContext() : base("IShoppingContext") { }
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<TipoArtigo> TiposArtigo { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ItemCompra> ItensCompra { get; set; }




    }
}   
