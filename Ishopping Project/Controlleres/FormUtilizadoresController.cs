using System;
using System.Collections.Generic;
using System.Linq;
using IShopping.Models;

namespace Ishopping_Project.Controlleres
{
    public static class FormUtilizadorController
    {
       
        public static List<Utilizador> ObterTodosUtilizadores()
        {
            using (var db = new IShoppingContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Utilizadores.ToList();
            }
        }

     
        public static bool CriarUtilizador(string nome, string username, string password, out string mensagem)
        {
            using (var db = new IShoppingContext())
            {
              
                bool userExiste = db.Utilizadores.Any(u => u.Username.ToLower() == username.ToLower());
                if (userExiste)
                {
                    mensagem = "Este Username já está a ser usado!";
                    return false;
                }

                Utilizador novo = new Utilizador
                {
                    Name = nome,
                    Username = username,
                    Password = password
                };

                db.Utilizadores.Add(novo);
                db.SaveChanges();

                mensagem = "Utilizador criado com sucesso!";
                return true;
            }
        }

       
        public static bool AtualizarUtilizador(int id, string nome, string username, string password, out string mensagem)
        {
            using (var db = new IShoppingContext())
            {
                
                bool userExiste = db.Utilizadores.Any(u => u.Username.ToLower() == username.ToLower() && u.Id != id);
                if (userExiste)
                {
                    mensagem = "Este Username já está ocupado!";
                    return false;
                }

                var utilizador = db.Utilizadores.Find(id);
                if (utilizador == null)
                {
                    mensagem = "Utilizador não encontrado.";
                    return false;
                }

                utilizador.Name = nome;
                utilizador.Username = username;

            
                if (!string.IsNullOrWhiteSpace(password))
                {
                    utilizador.Password = password;
                }

                db.SaveChanges();
                mensagem = "Dados atualizados com sucesso!";
                return true;
            }
        }


        public static bool ApagarUtilizador(int id, out string message)
        {
            using (var db = new IShoppingContext())
            {
                var utilizador = db.Utilizadores.Find(id);
                if (utilizador == null)
                {
                    message = "Utilizador não encontrado.";
                    return false;
                }

                db.Utilizadores.Remove(utilizador);
                db.SaveChanges();

                message = "Utilizador removido com sucesso!";
                return true;
            }
        }
    }
}