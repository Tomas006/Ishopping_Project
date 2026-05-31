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
    }
}