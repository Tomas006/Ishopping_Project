using IShopping.Controllers;
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

           
            this.Hide();

            formTipos.ShowDialog();

            this.Show();
        }

        private void btnGestaoUtilizadores_Click(object sender, EventArgs e)
        {
            FormUtilizadores formUtilizadores = new FormUtilizadores();


            this.Hide();

            formUtilizadores.ShowDialog();

            this.Show();

        }

        private void btnGestaoArtigos_Click(object sender, EventArgs e)
        {
            FormArtigos formArtigos = new FormArtigos();


            this.Hide();

            formArtigos.ShowDialog();

            this.Show();
        }

        private void btnGestaoOrcamentos_Click(object sender, EventArgs e)
        {
            FormOrcamentos formOrcamentos = new FormOrcamentos();


            this.Hide();

            formOrcamentos.ShowDialog();

            this.Show();
        }

        private void btnPlanearLista_Click(object sender, EventArgs e)
        {
            FormPlanearLista formPlanearLista = new FormPlanearLista();

            this.Hide();

            formPlanearLista.ShowDialog();

            this.Show();
        }

        private void btnModoCompra_Click(object sender, EventArgs e)
        {
            // 1. Vai buscar as compras em aberto (retorna List<Compra>)
            var comprasEmAberto = FormPlanearListaController.ObterListasPlaneadasEmAberto();

            if (comprasEmAberto == null || comprasEmAberto.Count == 0)
            {
                MessageBox.Show("Não há compras em aberto. Crie uma lista no Planeamento primeiro.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Abre o teu formulário visual passando a lista correta
            using (var formSelecao = new FormEscolherListaExistente(comprasEmAberto))
            {
                if (formSelecao.ShowDialog() == DialogResult.OK)
                {
                    int idDaCompra = formSelecao.CompraIdSelecionada;

                    this.Hide();
                    FormModoCompra formModoCompra = new FormModoCompra(idDaCompra);
                    formModoCompra.ShowDialog();
                    this.Show();
                }
            }
        }
    }
}
