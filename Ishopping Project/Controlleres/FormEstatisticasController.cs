using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using IShopping.Models; 

namespace IShopping.Controllers
{
    public static class FormEstatisticasController
    {
        
        public static (decimal totalGasto, int listasFechadas, decimal mediaOrcamentos) ObterResumoGeral()
        {
            using (var db = new IShoppingContext())
            {
                var totalGasto = db.Set<ItemCompra>()
                    .Where(i => i.Compra.Estado == "FECHADA" && i.Adquirido == true)
                    .Select(i => (decimal?)(i.QuantidadeComprada * i.PrecoUnitario))
                    .Sum() ?? 0m;

                var listasFechadas = db.Set<Compra>().Count(l => l.Estado == "FECHADA");

                var mediaOrcamentos = db.Set<Orcamento>()
                    .Select(o => (decimal?)o.ValorMaximo)
                    .Average() ?? 0m;

                return (totalGasto, listasFechadas, mediaOrcamentos);
            }
        }

        
        public static object ObterHistoricoGlobal()
        {
            using (var db = new IShoppingContext())
            {
                
                var comprasFechadas = db.Set<Compra>()
                    .Where(l => l.Estado == "FECHADA")
                    .Include(l => l.Itens)
                    .ToList();

                var orcamentos = db.Set<Orcamento>().ToList();

                return comprasFechadas.Select(lista => {
                    
                    var orcamentoMes = orcamentos
                        .FirstOrDefault(o => o.Mes == lista.DataFecho?.Month && o.Ano == lista.DataFecho?.Year)?
                        .ValorMaximo ?? 0m;

                   
                    decimal totalGastoLista = lista.Itens
                        .Where(i => i.Adquirido == true)
                        .Sum(i => (i.QuantidadeComprada * i.PrecoUnitario));

                    
                    int totalItensComprados = lista.Itens.Count(i => i.Adquirido == true);
                    double percPrevistos = 0;
                    double percNaoPrevistos = 0;

                    if (totalItensComprados > 0)
                    {
                        int previstos = lista.Itens.Count(i => i.Adquirido == true && i.PreviaComprar == true);
                        int naoPrevistos = lista.Itens.Count(i => i.Adquirido == true && i.PreviaComprar == false);

                        percPrevistos = Math.Round(((double)previstos / totalItensComprados) * 100, 1);
                        percNaoPrevistos = Math.Round(((double)naoPrevistos / totalItensComprados) * 100, 1);
                    }

                    return new
                    {
                        ID_Lista = lista.Id,
                        Nome = string.IsNullOrEmpty(lista.Nome) ? $"Compra #{lista.Id}" : lista.Nome,
                        Data_Conclusao = lista.DataFecho?.ToString("dd/MM/yyyy HH:mm") ?? "-",
                        Total_Gasto = totalGastoLista.ToString("C2"),
                        Orcamento_Mes = orcamentoMes.ToString("C2"),
                        Itens_Previstos = $"{percPrevistos}%",
                        Não_Previstos = $"{percNaoPrevistos}%"
                    };
                })
                .OrderByDescending(x => x.ID_Lista)
                .ToList();
            }
        }
        public static object ObterOrcamentoPorMes()
        {
            using (var db = new IShoppingContext())
            {
                var orcamentos = db.Set<Orcamento>().ToList();
                var compras = db.Set<Compra>()
                    .Include(c => c.Itens)
                    .Where(c => c.Estado == "FECHADA")
                    .ToList();

                return orcamentos.Select(o =>
                {
                    decimal totalGasto = compras
                        .Where(c => c.DataFecho.HasValue
                            && c.DataFecho.Value.Month == o.Mes
                            && c.DataFecho.Value.Year == o.Ano)
                        .SelectMany(c => c.Itens.Where(i => i.Adquirido))
                        .Sum(i => (decimal?)(i.QuantidadeComprada * i.PrecoUnitario)) ?? 0m;

                    return new
                    {
                        Mes = o.Mes,
                        Ano = o.Ano,
                        Orcamento = o.ValorMaximo.ToString("C2"),
                        Total_Gasto = totalGasto.ToString("C2"),
                        Diferenca = (o.ValorMaximo - totalGasto).ToString("C2")
                    };
                })
                .OrderBy(x => x.Ano).ThenBy(x => x.Mes)
                .ToList();
            }
        }

        public static object ObterPercentivosPorCompra()
        {
            using (var db = new IShoppingContext())
            {
                var compras = db.Set<Compra>()
                    .Include(c => c.Itens)
                    .Where(c => c.Estado == "FECHADA")
                    .ToList();

                return compras.Select(c =>
                {
                    int total = c.Itens.Count(i => i.Adquirido);
                    double percPrev = total > 0
                        ? Math.Round((double)c.Itens.Count(i => i.Adquirido && i.PreviaComprar) / total * 100, 1)
                        : 0;
                    double percNaoPrev = total > 0 ? Math.Round(100 - percPrev, 1) : 0;

                    return new
                    {
                        Compra = string.IsNullOrEmpty(c.Nome) ? $"Compra #{c.Id}" : c.Nome,
                        Data = c.DataFecho?.ToString("dd/MM/yyyy") ?? "-",
                        Previstos = $"{percPrev}%",
                        Nao_Previstos = $"{percNaoPrev}%"
                    };
                })
                .OrderByDescending(x => x.Compra)
                .ToList();
            }
        }

        public static decimal SugerirOrcamento()
        {
            using (var db = new IShoppingContext())
            {
                var orcamentos = db.Set<Orcamento>().Select(o => (decimal?)o.ValorMaximo).ToList();
                if (orcamentos.Count == 0) return 0;
                return Math.Round(orcamentos.Average() ?? 0, 2);
            }
        }

        public static object SugerirListaCompras()
        {
            using (var db = new IShoppingContext())
            {
                int diaAtual = DateTime.Now.Day;
                int semanaAtual = (int)Math.Ceiling(diaAtual / 7.0);

                var comprasFechadas = db.Set<Compra>()
                    .Include(c => c.Itens.Select(i => i.Artigo))
                    .Where(c => c.Estado == "FECHADA" && c.DataCriacao.Month != DateTime.Now.Month)
                    .ToList()
                    .Where(c =>
                    {
                        int semana = (int)Math.Ceiling(c.DataCriacao.Day / 7.0);
                        return semana == semanaAtual;
                    })
                    .ToList();

                if (!comprasFechadas.Any())
                    return new List<object>();

                return comprasFechadas
                    .SelectMany(c => c.Itens.Where(i => i.PreviaComprar && i.Artigo != null))
                    .GroupBy(i => new { i.ArtigoId, Nome = i.Artigo.Nome })
                    .Select(g => new
                    {
                        Artigo = g.Key.Nome,
                        Qtd_Media_Sugerida = Math.Round(g.Average(i => i.QuantidadeComprada), 0)
                    })
                    .OrderByDescending(x => x.Qtd_Media_Sugerida)
                    .ToList();
            }
        }
    }
}