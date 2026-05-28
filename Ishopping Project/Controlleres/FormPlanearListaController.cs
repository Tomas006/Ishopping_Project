using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IShopping.Models;

namespace IShopping.Controllers
{
    public static class FormPlanearListaController
    {
        // 1. CARREGAR ARTIGOS PARA A COMBOBOX (Com Include para evitar ObjectDisposedException)
        public static List<Artigo> ObterArtigos()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.Artigos
                         .Include("TipoArtigo")
                         .OrderBy(a => a.Nome)
                         .ToList();
            }
        }

        // 2. OBTER VALOR DO ORÇAMENTO DO MÊS ATUAL
        public static decimal ObterOrcamentoAtual()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                int mesAtual = DateTime.Now.Month;
                int anoAtual = DateTime.Now.Year;

                var orcamento = db.Orcamentos
                                  .FirstOrDefault(o => o.Mes == mesAtual && o.Ano == anoAtual);

                return orcamento != null ? orcamento.ValorMaximo : 0;
            }
        }

        // 3. VAI BUSCAR TODAS AS COMPRAS EM ABERTO
        public static List<Compra> ObterListasPlaneadasEmAberto()
        {
            using (var db = new IShoppingContext())
            {
                return db.Compras
                    .Include("Itens")
                    .Include("Itens.Artigo")
                    .Include("Itens.Artigo.TipoArtigo")
                    .Where(c => !c.EstaFechada)
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();
            }
        }

        // 4. CARREGA OS ITENS DE UMA COMPRA ESPECÍFICA (Para preencher a Grid de planeamento)
        public static List<ItemCompra> ObterItensDaCompra(int compraId)
        {
            using (var db = new IShoppingContext())
            {
                return db.ItensCompra
                    .Include("Artigo")
                    .Where(i => i.CompraId == compraId)
                    .ToList();
            }
        }

        // 5. CARREGA A COMPRA COM OS DETALHES TODOS MASTIGADOS PARA O PLANEAMENTO NÃO REBENTAR
        public static Compra ObterCompraCompletaParaPlaneamento(int compraId)
        {
            using (var db = new IShoppingContext())
            {
                return db.Compras
                    .Include("Itens")
                    .Include("Itens.Artigo")
                    .Include("Itens.Artigo.TipoArtigo")
                    .FirstOrDefault(c => c.Id == compraId);
            }
        }

        // 6. GRAVAR NOVA COMPRA E OS ITENS PREVISTOS (INSERT)
        public static string GravarPlaneamento(string nomeLista, List<ItemPrevisto> itens, int idUtilizador)
        {
            try
            {
                using (var db = new IShoppingContext())
                {
                    var novaCompra = new Compra
                    {
                        Nome = nomeLista,
                        DataCriacao = DateTime.Now,
                        DataAlteracao = null,
                        DataFecho = null,
                        EstaFechada = false,
                        CriadoPorId = idUtilizador
                    };

                    db.Compras.Add(novaCompra);
                    db.SaveChanges();

                    foreach (var itemEmMemoria in itens)
                    {
                        string nomeArtigo = itemEmMemoria.Artigo != null ? itemEmMemoria.Artigo.Nome : "Artigo Sem Nome";
                        decimal precoArtigo = itemEmMemoria.Artigo != null ? itemEmMemoria.Artigo.Preco : 0;

                        var linhaDetalhe = new ItemCompra
                        {
                            CompraId = novaCompra.Id,
                            ArtigoId = itemEmMemoria.ArtigoId,
                            Nome = nomeArtigo,
                            QuantidadeComprada = itemEmMemoria.QuantidadePrevista,
                            PrecoUnitario = precoArtigo,
                            Adquirido = false,
                            CriadoPorId = idUtilizador,
                            DataCriacao = DateTime.Now,
                            DataAlteracao = null
                        };

                        db.ItensCompra.Add(linhaDetalhe);
                    }

                    db.SaveChanges();
                    return "Sucesso";
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
            }
        }

        // 7. ATUALIZAR UMA LISTA JÁ EXISTENTE (UPDATE)
        public static string AtualizarPlaneamento(int compraId, List<ItemPrevisto> itens, int idUtilizador)
        {
            try
            {
                using (var db = new IShoppingContext())
                {
                    var compraExistente = db.Compras.FirstOrDefault(c => c.Id == compraId);
                    if (compraExistente == null) return "Lista não encontrada na Base de Dados.";

                    compraExistente.DataAlteracao = DateTime.Now;
                    compraExistente.AlteradoPorId = idUtilizador;

                    var itensAntigos = db.ItensCompra.Where(i => i.CompraId == compraId);
                    db.ItensCompra.RemoveRange(itensAntigos);

                    foreach (var itemEmMemoria in itens)
                    {
                        string nomeArtigo = itemEmMemoria.Artigo != null ? itemEmMemoria.Artigo.Nome : "Artigo Sem Nome";
                        decimal precoArtigo = itemEmMemoria.Artigo != null ? itemEmMemoria.Artigo.Preco : 0;

                        var linhaDetalhe = new ItemCompra
                        {
                            CompraId = compraId,
                            ArtigoId = itemEmMemoria.ArtigoId,
                            Nome = nomeArtigo,
                            QuantidadeComprada = itemEmMemoria.QuantidadePrevista,
                            PrecoUnitario = precoArtigo,
                            Adquirido = false,
                            CriadoPorId = idUtilizador,
                            DataCriacao = DateTime.Now
                        };

                        db.ItensCompra.Add(linhaDetalhe);
                    }

                    db.SaveChanges();
                    return "Sucesso";
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
            }
        }
    }
}