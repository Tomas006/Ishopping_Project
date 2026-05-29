using System;
using System.Collections.Generic;
using System.Linq;
using IShopping.Models;

namespace IShopping.Controllers
{
    public static class FormHistoricoListasController
    {
      
        public static List<object> ObterTodasAsComprasComCriador()
        {
            using (var db = new IShoppingContext())
            {
                var utilizadores = db.Utilizadores.ToDictionary(u => u.Id, u => u.Name);

                var compras = db.Compras.OrderByDescending(c => c.DataCriacao).ToList();

                var resultado = new List<object>();

                foreach (var c in compras)
                {
                    string nomeCriador = "Desconhecido";
                    if (utilizadores.ContainsKey(c.CriadoPorId))
                    {
                        nomeCriador = utilizadores[c.CriadoPorId];
                    }

                    resultado.Add(new
                    {
                        IdLista = c.Id, 
                        NomeLista = c.Nome,
                        Estado = c.Estado,
                        DataCriacao = c.DataCriacao,
                        CriadorNome = nomeCriador 
                    });
                }

                return resultado;
            }
        }
    }
}