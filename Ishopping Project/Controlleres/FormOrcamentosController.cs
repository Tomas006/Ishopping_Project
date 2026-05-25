using System;
using System.Collections.Generic;
using System.Data.Entity;  
using System.Linq;
using IShopping.Models;

namespace IShopping.Controllers
{
    public static class FormOrcamentoController
    {
       
        public static List<Orcamento> ObterTodosOrcamentos()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                
                return db.Orcamentos
                         .Include(o => o.CriadoPor)
                         .Include(o => o.AlteradoPor)
                         .OrderByDescending(o => o.Ano)
                         .ThenByDescending(o => o.Mes)
                         .ToList();
            }
        }

        
        public static string GravarOrcamento(int mes, int ano, decimal valorMaximo, int utilizadorLogadoId)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                
                bool existeDuplicado = db.Orcamentos.Any(o => o.Mes == mes && o.Ano == ano);

                if (existeDuplicado)
                {
                    return "Já existe um orçamento definido para este mês e ano! Se quiseres mudar o valor, usa o botão Atualizar.";
                }

                
                Orcamento novo = new Orcamento
                {
                    Mes = mes,
                    Ano = ano,
                    ValorMaximo = valorMaximo,
                    CriadoPorId = utilizadorLogadoId 
                };

                db.Orcamentos.Add(novo);
                db.SaveChanges();

                return "Sucesso";
            }
        }

      
        public static string AtualizarOrcamento(int id, decimal novoValor, int utilizadorLogadoId)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                
                Orcamento orcamentoBD = db.Orcamentos.Find(id);

                if (orcamentoBD == null)
                {
                    return "Orçamento não encontrado na base de dados.";
                }

                
                orcamentoBD.ValorMaximo = novoValor;

                orcamentoBD.AlteradoPorId = utilizadorLogadoId;

                db.Entry(orcamentoBD).State = EntityState.Modified;
                db.SaveChanges();

                return "Sucesso";
            }
        }

        
        public static bool ApagarOrcamento(int id)
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                Orcamento orcamentoBD = db.Orcamentos.Find(id);

                if (orcamentoBD != null)
                {
                    db.Orcamentos.Remove(orcamentoBD);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}