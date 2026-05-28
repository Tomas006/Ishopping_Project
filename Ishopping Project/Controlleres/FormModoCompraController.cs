using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using IShopping.Models;

namespace IShopping.Controllers
{
    public static class FormModoCompraController
    {
        public static List<Compra> ObterComprasEmAberto()
        {
            using (var db = new IShoppingContext())
            {
                return db.Compras
                    .Where(c => !c.EstaFechada)
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();
            }
        }

        public static Compra ObterCompraParaProcessar(int compraId)
        {
            using (var db = new IShoppingContext())
            {
             
                return db.Compras
                    .Include("Itens")
                    .Include("Itens.Artigo")
                    .FirstOrDefault(c => c.Id == compraId);
            }
        }

        public static decimal ObterOrcamentoDoMes(int mes, int ano)
        {
            using (var db = new IShoppingContext())
            {
                var orcamento = db.Orcamentos.FirstOrDefault(o => o.Mes == mes && o.Ano == ano);
                return orcamento != null ? orcamento.ValorMaximo : 0;
            }
        }

        public static List<TipoArtigo> ObterTiposArtigo()
        {
            using (var db = new IShoppingContext())
            {
                return db.TiposArtigos.OrderBy(t => t.Nome).ToList();
            }
        }

        public static List<Artigo> ObterArtigosPorTipo(int tipoId)
        {
            using (var db = new IShoppingContext())
            {
                return db.Artigos
                    .Where(a => a.TipoArtigoId == tipoId)
                    .OrderBy(a => a.Nome)
                    .ToList();
            }
        }
        public static bool AtualizarEstadoCompra(Compra compraModificada)
        {
            using (var db = new IShoppingContext())
            {
                var compra = db.Compras.Find(compraModificada.Id);
                if (compra == null) return false;

                compra.Estado = compraModificada.Estado;
                compra.AlteradoPorId = compraModificada.AlteradoPorId;
                compra.DataAlteracao = compraModificada.DataAlteracao;

                db.Entry(compra).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool AdicionarItemNaoPrevisto(int compraId, int artigoId, string nomeArtigo,
            int quantidade, decimal preco, string observacoes, int utilizadorId)
        {
            using (var db = new IShoppingContext())
            {
                var novoItem = new ItemCompra
                {
                    CompraId = compraId,
                    ArtigoId = artigoId,
                    Nome = nomeArtigo,
                    QuantidadeComprada = quantidade,
                    PrecoUnitario = preco,
                    Observacoes = observacoes,
                    PreviaComprar = false,
                    Adquirido = true, 
                    CriadoPorId = utilizadorId,
                    DataCriacao = DateTime.Now
                };

                db.ItensCompra.Add(novoItem);
                return db.SaveChanges() > 0;
            }
        }

        public static bool MarcarItemComoAdquirido(int itemId, int quantidade, decimal preco, int utilizadorId)
        {
            using (var db = new IShoppingContext())
            {
                var item = db.ItensCompra.Find(itemId);
                if (item == null) return false;

                
                item.Adquirido = !item.Adquirido;
                item.QuantidadeComprada = quantidade;
                item.PrecoUnitario = preco;
                item.AlteradoPorId = utilizadorId;
                item.DataAlteracao = DateTime.Now;

                db.Entry(item).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

       
        public static bool LimparCarrinhoEExtras(int compraId, int utilizadorId)
        {
            using (var db = new IShoppingContext())
            {
                try
                {
                    
                    var itensExtras = db.ItensCompra.Where(i => i.CompraId == compraId && !i.PreviaComprar);
                    db.ItensCompra.RemoveRange(itensExtras);

                    
                    var itensPrevistos = db.ItensCompra.Where(i => i.CompraId == compraId && i.PreviaComprar);
                    foreach (var item in itensPrevistos)
                    {
                        item.Adquirido = false;
                        item.DataAlteracao = DateTime.Now;
                        item.AlteradoPorId = utilizadorId;
                    }

                    return db.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool FecharCompra(int compraId, int utilizadorId)
        {
            using (var db = new IShoppingContext())
            {
                var compra = db.Compras.Find(compraId);
                if (compra == null) return false;

                
                compra.EstaFechada = true;
                compra.Estado = "FECHADA";
                compra.DataFecho = DateTime.Now;
                compra.FechadoPorId = utilizadorId;

                db.Entry(compra).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}