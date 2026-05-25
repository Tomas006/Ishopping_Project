using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IShopping.Models;

namespace Ishopping_Project.Controlleres
{
    public static class FormArtigoController
    {
       
        public static List<Artigo> ObterTodosArtigos()
        {
            using (var db = new IShoppingContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Artigos.Include(a => a.TipoArtigo).ToList();
            }
        }

       
        public static List<TipoArtigo> ObterTiposArtigo()
        {
            using (var db = new IShoppingContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.TiposArtigos.ToList();
            }
        }

       
        public static bool CriarArtigo(string nome, decimal preco, int tipoArtigoId, out string mensagem)
        {
            using (var db = new IShoppingContext())
            {
                try
                {
                    Artigo novo = new Artigo
                    {
                        Nome = nome,
                        Preco = preco,
                        TipoArtigoId = tipoArtigoId
                    };

                    db.Artigos.Add(novo);
                    db.SaveChanges();

                    mensagem = "Artigo criado com sucesso!";
                    return true;
                }
                catch (Exception ex)
                {
                    mensagem = "Erro ao criar artigo: " + ex.Message;
                    return false;
                }
            }
        }
        
        public static bool AtualizarArtigo(int id, string nome, decimal preco, int tipoArtigoId, out string mensagem)
        {
            using (var db = new IShoppingContext())
            {
                try
                {
                    var artigo = db.Artigos.Find(id);
                    if (artigo == null)
                    {
                        mensagem = "Artigo não encontrado.";
                        return false;
                    }
                    artigo.Nome = nome;
                    artigo.Preco = preco;
                    artigo.TipoArtigoId = tipoArtigoId;
                    db.SaveChanges();
                    mensagem = "Artigo atualizado com sucesso!";
                    return true;
                }
                catch (Exception ex)
                {
                    mensagem = "Erro ao atualizar artigo: " + ex.Message;
                    return false;
                }
            }
        }

        
        public static bool ApagarArtigo(int id, out string message)
        {
            using (var db = new IShoppingContext())
            {
                try
                {
                    var artigo = db.Artigos.Find(id);
                    if (artigo == null)
                    {
                        message = "Artigo não encontrado.";
                        return false;
                    }
                    db.Artigos.Remove(artigo);
                    db.SaveChanges();
                    message = "Artigo removido com sucesso!";
                    return true;
                }
                catch (Exception ex)
                {
                    message = "Erro ao eliminar artigo: " + ex.Message;
                    return false;
                }
            }
        }
    }
}