using IShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping_Project.Controlleres
{
    internal class FormTipoArtigoController
    {
        // Preencher DataView com os Tipos de Artigo
        public static object ObterTodosTipos()
       {
            using (IShoppingContext db = new IShoppingContext())
            {
           
            return db.TiposArtigo
                     .Select(t => new { t.Id, t.Nome })
                     .OrderBy(t => t.Nome)
                     .ToList();
            }
       }

       
        public static bool CriarTipoArtigo(string nome, out string mensagem)
        {
            mensagem = "";
            try
            {
                using (IShoppingContext db = new IShoppingContext())
                {
                    if (db.TiposArtigo.Any(t => t.Nome.ToLower() == nome.ToLower()))
                    {
                        mensagem = "Já existe um tipo de artigo com esse nome.";
                        return false;
                    }

                    var novoTipo = new TipoArtigo { Nome = nome };
                    db.TiposArtigo.Add(novoTipo);
                    db.SaveChanges();

                    mensagem = "Tipo de artigo gravado com sucesso.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensagem = $"Erro na Base de Dados: {ex.Message}";
                return false;
            }
        }

    
        public static bool AtualizarTipoArtigo(int id, string novoNome, out string mensagem)
        {
            mensagem = "";
            try
            {
                using (IShoppingContext db = new IShoppingContext())
                {
                    var tipoArtigo = db.TiposArtigo.Find(id);
                    if (tipoArtigo != null)
                    {
                        tipoArtigo.Nome = novoNome;
                        db.SaveChanges();
                        mensagem = "Alterações guardadas com sucesso.";
                        return true;
                    }

                    mensagem = "Tipo de artigo não encontrado.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensagem = $"Erro ao atualizar: {ex.Message}";
                return false;
            }
        }

       
        public static bool ApagarTipoArtigo(int id, out string mensagem)
        {
            mensagem = "";
            try
            {
                using (IShoppingContext db = new IShoppingContext())
                {
                    var tipoArtigo = db.TiposArtigo.Find(id);
                    if (tipoArtigo != null)
                    {
                        db.TiposArtigo.Remove(tipoArtigo);
                        db.SaveChanges();
                        mensagem = "Tipo de artigo apagado com sucesso.";
                        return true;
                    }

                    mensagem = "Tipo de artigo não encontrado.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensagem = $"Erro: Certifique-se de que não existem artigos associados a este tipo.\n\nDetalhes: {ex.Message}";
                return false;
            }
        }
    }
}