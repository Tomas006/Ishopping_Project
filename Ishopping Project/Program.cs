using Ishopping_Project.Views;
using System;
using System.Windows.Forms;

namespace Ishopping_Project
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Cria e abre o Form1 (Login) como uma janela de diálogo
            FormLogin login = new FormLogin();

            // 2. Se o utilizador fizer login com sucesso, o DialogResult passa a ser OK
            if (login.ShowDialog() == DialogResult.OK)
            {
                // O Form1 fecha e descarrega da memória, e o programa abre o formulário principal
                // (Substitui 'FormPrincipal' pelo nome exato do teu segundo formulário, ex: Form2)
                Application.Run(new FormPrincipal());
            }
            else
            {
                // Se o utilizador fechou a janela no 'X' sem fazer login, o programa fecha de vez
                Application.Exit();
            }
        }
    }
}