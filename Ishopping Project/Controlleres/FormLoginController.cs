using IShopping.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Ishopping_Project.Controlleres
{
    internal class FormLoginController
    {
        private static string GerarHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        public static bool Autenticar(string login, string password, out string mensagem)
        {
            mensagem = "";

            if (login.Trim() == "" || password == "")
            {
                mensagem = "Deve introduzir as suas credenciais";
                return false;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                string passwordHash = GerarHash(password);

                Utilizador utilizador = db.Utilizadores.FirstOrDefault(u => u.Username == login
                    && u.Password == passwordHash);

                if (utilizador == null)
                {
                    mensagem = "Login ou password incorretos";
                    return false;
                }

                Sessao.UtilizadorAtual = utilizador.Username;
                Sessao.UtilizadorAtualObj = utilizador;
                mensagem = "Login efetuado com sucesso";
                return true;
            }
        }

        public static bool Registar(string nome, string login, string password, out string mensagem)
        {
            mensagem = "";

            if (nome.Trim() == "" || login.Trim() == "" || password == "")
            {
                mensagem = "Deve preencher todos os campos (Nome, Username e Password).";
                return false;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                bool existe = db.Utilizadores.Any(u => u.Username == login);

                if (existe)
                {
                    mensagem = "Este nome de utilizador já está em uso.";
                    return false;
                }

                Utilizador novoUtilizador = new Utilizador
                {
                    Name = nome,
                    Username = login,
                    Password = GerarHash(password)  // ← hash aqui
                };

                db.Utilizadores.Add(novoUtilizador);
                db.SaveChanges();

                mensagem = "Utilizador registado com sucesso!";
                return true;
            }
        }
    }
}