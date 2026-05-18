using IShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping_Project.Controlleres
{
    internal class Form1Controller
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
