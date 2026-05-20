using IShopping.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ishopping_Project.Views
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Sessao.UtilizadorAtual))
            {

                lblUserAutenticado.Text = $"Bem-vindo, {Sessao.UtilizadorAtual}!";
            }
            else
              
                lblUserAutenticado.Text = "Bem-vindo ao iShopping!";
            }

        private void btnTiposArtigos_Click(object sender, EventArgs e)
        {
            FormTipoArtigo formTipos = new FormTipoArtigo();


            formTipos.Show();
            this.Hide();
        }

        private void btnGestaoUtilizadores_Click(object sender, EventArgs e)
        {
            
        }
    }
    }
