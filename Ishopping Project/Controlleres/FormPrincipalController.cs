using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Entity;
using IShopping.Models; 

namespace IShopping.Controllers
{
    public static class FormPrincipalController 
    {
        public static string GerarConteudoCSV()
        {
            using (var db = new IShoppingContext())
            {
                var comprasFechadas = db.Set<Compra>()
                    .Where(c => c.Estado == "FECHADA")
                    .Include(c => c.Itens.Select(i => i.Artigo))
                    .ToList();

                var csv = new StringBuilder();

                
                csv.AppendLine("NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario");

                foreach (var compra in comprasFechadas)
                {
                    foreach (var item in compra.Itens)
                    {
                        string nomeCompra = compra.Nome ?? $"Compra #{compra.Id}";
                        string dataCriacao = compra.DataCriacao.ToString("dd/MM/yyyy HH:mm");
                        string dataFechada = compra.DataFecho?.ToString("dd/MM/yyyy HH:mm") ?? "-";
                        string nomeArtigo = item.Artigo?.Nome ?? item.Nome ?? "Artigo Indefinido";
                        string artigoPrevisto = item.PreviaComprar ? "Sim" : "Não";
                        string artigoNaoPrevisto = !item.PreviaComprar ? "Sim" : "Não";
                        string qtdPrevista = item.PreviaComprar ? item.QuantidadeComprada.ToString() : "0";
                        string qtdAdquirida = item.Adquirido ? item.QuantidadeComprada.ToString() : "0";
                        string precoUnitario = item.PrecoUnitario.ToString("F2");

                        csv.AppendLine($"{nomeCompra};{dataCriacao};{dataFechada};{nomeArtigo};{artigoPrevisto};{artigoNaoPrevisto};{qtdPrevista};{qtdAdquirida};{precoUnitario}");
                    }
                }

                return csv.ToString();
            }
        }
        public static (decimal limite, decimal gasto, string mesAno) ObterDadosOrcamentoAtual()
        {
            using (var db = new IShoppingContext())
            {
                var agora = DateTime.Now;
                string mesAnoTexto = agora.ToString("MMMM / yyyy");

                
                var orcamento = db.Set<Orcamento>()
                    .FirstOrDefault(o => o.Mes == agora.Month && o.Ano == agora.Year);

                decimal limite = orcamento?.ValorMaximo ?? 0m;

                decimal gasto = db.Set<ItemCompra>()
                    .Where(i => i.Compra.DataFecho.Value.Month == agora.Month &&
                                i.Compra.DataFecho.Value.Year == agora.Year &&
                                i.Adquirido == true)
                    .Select(i => (decimal?)(i.QuantidadeComprada * i.PrecoUnitario))
                    .Sum() ?? 0m;

                return (limite, gasto, mesAnoTexto);
            }
        }

        public static object ObterComprasAtivas()
        {
            using (var db = new IShoppingContext())
            {
                return db.Set<Compra>()
                    .Where(c => c.Estado == "PLANEADA" || c.Estado == "EM COMPRA") 
                    .Select(c => new
                    {
                        ID = c.Id,
                        Nome = c.Nome ?? "Compra Sem Nome",
                        Criada_Em = c.DataCriacao
                    })
                    .ToList();
            }
        }

        public static object ObterUltimasComprasFechadas()
        {
            using (var db = new IShoppingContext())
            {
                return db.Set<Compra>()
                    .Where(c => c.Estado == "FECHADA")
                    .OrderByDescending(c => c.DataFecho)
                    .Take(5) 
                    .Select(c => new
                    {
                        ID = c.Id,
                        Nome = c.Nome ?? "Compra Sem Nome",
                        Fechada_Em = c.DataFecho
                    })
                    .ToList();
            }
        }
    }
}