using IShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;


namespace Ishopping_Project.Controlleres
{
    internal class FormLoginController
    {

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
                Utilizador utilizador = db.Utilizadores.FirstOrDefault(u => u.Username == login
                && u.Password == password);

                if (utilizador == null)
                {
                    mensagem = "Login ou password incorretos";
                    return false;

                }

                Sessao.UtilizadorAtual = utilizador.Username;
                mensagem = "Login efetuado com sucesso";

                return true;
            }
        }

        public static bool Registar(string nome, string login, string password, out string mensagem)
        {
            mensagem = "";

            // 1. Validação de campos vazios (incluindo o nome)
            if (nome.Trim() == "" || login.Trim() == "" || password == "")
            {
                mensagem = "Deve preencher todos os campos (Nome, Username e Password).";
                return false;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // 2. Verificar se o username já está registado
                bool existe = db.Utilizadores.Any(u => u.Username == login);

                if (existe)
                {
                    mensagem = "Este nome de utilizador já está em uso.";
                    return false;
                }

                // 3. Criar o novo utilizador com o Nome incluído
                Utilizador novoUtilizador = new Utilizador
                {
                    Name = nome,       
                    Username = login,
                    Password = password
                };

                // Adicionar e salvar na base de dados
                db.Utilizadores.Add(novoUtilizador);
                db.SaveChanges();

                mensagem = "Utilizador registado com sucesso!";
                return true;
            }
        }

    }
}
