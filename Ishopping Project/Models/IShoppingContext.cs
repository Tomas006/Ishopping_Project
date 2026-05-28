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
        public IShoppingContext() : base("IShoppingContext")
        {
            
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<IShoppingContext>());
            this.Database.Initialize(force: false);
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<TipoArtigo> TiposArtigos { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ItemCompra> ItensCompra { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 1. Configuração para COMPRA
            // Evita o cascade delete nas propriedades de auditoria (AlteradoPor e FechadoPor)
            modelBuilder.Entity<Compra>()
                .HasOptional(c => c.AlteradoPor)
                .WithMany()
                .HasForeignKey(c => c.AlteradoPorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Compra>()
                .HasOptional(c => c.FechadoPor)
                .WithMany()
                .HasForeignKey(c => c.FechadoPorId)
                .WillCascadeOnDelete(false);


            // 2. Configuração para ITEMCOMPRA
            // Remove o cascade delete total do Utilizador para o ItemCompra para quebrar o ciclo
            modelBuilder.Entity<ItemCompra>()
                .HasRequired(i => i.CriadoPor)
                .WithMany()
                .HasForeignKey(i => i.CriadoPorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemCompra>()
                .HasOptional(i => i.AlteradoPor)
                .WithMany()
                .HasForeignKey(i => i.AlteradoPorId)
                .WillCascadeOnDelete(false);


            // 3. Configuração para ORÇAMENTO
            modelBuilder.Entity<Orcamento>()
                .HasOptional(o => o.AlteradoPor)
                .WithMany()
                .HasForeignKey(o => o.AlteradoPorId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}