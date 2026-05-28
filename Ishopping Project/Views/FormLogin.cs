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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmarEntrar_Click(object sender, EventArgs e)
        {
            string mensagem;
            bool ok = FormLoginController.Autenticar(textUsernameEntrar.Text, textPasswordEntrar.Text, out mensagem);

            MessageBox.Show(mensagem, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (ok)
            {
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelarEntrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirmarRegistar_Click(object sender, EventArgs e)
        {
            if (FormLoginController.Registar(textNome.Text, textUsernameRegistar.Text, textPasswordRegistar.Text, out string mensagem))
            {
                
                MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

             
               
                tabController.SelectedIndex = 1;

                textNome.Clear();
                textUsernameRegistar.Clear();
                textPasswordRegistar.Clear();
            }
            else
            {
                
                MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
