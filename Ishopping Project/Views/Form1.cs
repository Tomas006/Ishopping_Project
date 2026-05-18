using Ishopping_Project.Controlleres;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ishopping_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmarEntrar_Click(object sender, EventArgs e)
        {
            string mensagem;
            bool ok = Form1Controller.Autenticar(textUsernameEntrar.Text, textPasswordEntrar.Text, out mensagem);
            MessageBox.Show(mensagem);
            if (ok)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
