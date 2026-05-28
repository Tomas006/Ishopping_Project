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


            FormLogin login = new FormLogin();


            if (login.ShowDialog() == DialogResult.OK)
            {

                Application.Run(new FormPrincipal());
        }
                else
                {

                    Application.Exit();
                }
}
    }
}