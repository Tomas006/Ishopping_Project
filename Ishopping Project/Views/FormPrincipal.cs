using IShopping.Controllers;
using IShopping.Models;
using IShopping.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        public void FormPrincipal_Load(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrEmpty(Sessao.UtilizadorAtual))
            {
                lblUserAutenticado.Text = $"Bem-vindo, {Sessao.UtilizadorAtual}!";
            }
            else
            {
                lblUserAutenticado.Text = "Bem-vindo ao iShopping!";
            }

           

            dtavgListaDeComprasAtivas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtavgHistoricoUltimasComprasFechadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AtualizarDashboard();
        }

        private void AtualizarDashboard()
        {
            try
            {
                var dadosOrcamento = FormPrincipalController.ObterDadosOrcamentoAtual();

                groupBox1.Text = $"Orçamento Atual: {dadosOrcamento.mesAno}";

                labelLimiteOrcamento.Text = $"Limite: {dadosOrcamento.limite:C2}";
                labelGastoOrcamento.Text = $"Gasto: {dadosOrcamento.gasto:C2}";

                if (dadosOrcamento.limite > 0)
                {
                    int percentagem = (int)((dadosOrcamento.gasto / dadosOrcamento.limite) * 100);
                    progressBarOrcamentoAtual.Value = Math.Min(percentagem, 100);
                }
                else
                {
                    progressBarOrcamentoAtual.Value = 0;
                }

                if (dadosOrcamento.limite == 0)
                {
                    lblAlerta.Text = "⚠️ Sem orçamento definido para este mês.";
                    lblAlerta.ForeColor = Color.DarkOrange;
                    lblAlerta.Visible = true;
                    progressBarOrcamentoAtual.Value = 0;
                }
                else if (dadosOrcamento.gasto > dadosOrcamento.limite)
                {
                    lblAlerta.Text = "⚠️ ATENÇÃO: O orçamento mensal foi ultrapassado!";
                    lblAlerta.ForeColor = Color.DarkRed;
                    lblAlerta.Visible = true;
                }
                else if ((dadosOrcamento.gasto / dadosOrcamento.limite) >= 0.8m)
                {
                    lblAlerta.Text = "⚡ Cuidado: Já gastou mais de 80% do orçamento!";
                    lblAlerta.ForeColor = Color.DarkOrange;
                    lblAlerta.Visible = true;
                }
                else
                {
                    lblAlerta.Text = "✅ Orçamento controlado e seguro.";
                    lblAlerta.ForeColor = Color.Green;
                    lblAlerta.Visible = true;
                }

                dtavgListaDeComprasAtivas.DataSource = FormPrincipalController.ObterComprasAtivas();
                dtavgHistoricoUltimasComprasFechadas.DataSource = FormPrincipalController.ObterUltimasComprasFechadas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar os dados da Dashboard: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTiposArtigos_Click(object sender, EventArgs e)
        {
            FormTipoArtigo formTipos = new FormTipoArtigo();
            this.Hide();
            formTipos.ShowDialog();
            this.Show();
            AtualizarDashboard();
        }

        private void btnGestaoUtilizadores_Click(object sender, EventArgs e)
        {
            FormUtilizadores formUtilizadores = new FormUtilizadores();
            this.Hide();
            formUtilizadores.ShowDialog();
            this.Show();
            AtualizarDashboard();
        }

        private void btnGestaoArtigos_Click(object sender, EventArgs e)
        {
            FormArtigos formArtigos = new FormArtigos();
            this.Hide();
            formArtigos.ShowDialog();
            this.Show();
            AtualizarDashboard();
        }

        private void btnGestaoOrcamentos_Click(object sender, EventArgs e)
        {
            FormOrcamentos formOrcamentos = new FormOrcamentos();
            this.Hide();
            formOrcamentos.ShowDialog();
            this.Show();
            AtualizarDashboard();
        }

        private void btnPlanearLista_Click(object sender, EventArgs e)
        {
            FormPlanearLista formPlanearLista = new FormPlanearLista();
            this.Hide();
            formPlanearLista.ShowDialog();
            this.Show();
            AtualizarDashboard();
        }

        private void btnModoCompra_Click(object sender, EventArgs e)
        {
            var comprasEmAberto = FormPlanearListaController.ObterListasPlaneadasEmAberto();

            if (comprasEmAberto == null || comprasEmAberto.Count == 0)
            {
                MessageBox.Show("Não há compras em aberto. Crie uma lista no Planeamento primeiro.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var formSelecao = new FormEscolherListaExistente(comprasEmAberto))
            {
                if (formSelecao.ShowDialog() == DialogResult.OK)
                {
                    int idDaCompra = formSelecao.CompraIdSelecionada;

                    this.Hide();
                    FormModoCompra formModoCompra = new FormModoCompra(idDaCompra);
                    formModoCompra.ShowDialog();
                    this.Show();
                    AtualizarDashboard();
                }
            }
        }

        private void btnVerListas_Click(object sender, EventArgs e)
        {
            FormHistoricoListas formHistotiricoListas = new FormHistoricoListas();
            this.Hide();
            formHistotiricoListas.ShowDialog();
            this.Show();
            AtualizarDashboard();
        }

        private void btnEstatisticas_Click(object sender, EventArgs e)
        {
            FormEstatisticas formEstatisticas = new FormEstatisticas();
            this.Hide();
            formEstatisticas.ShowDialog();
            this.Show();
            AtualizarDashboard();
        }

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Ficheiros CSV (*.csv)|*.csv";
                    saveFileDialog.Title = "Exportar Histórico de Compras";
                    saveFileDialog.FileName = $"Historico_Compras_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string conteudoCsv = FormPrincipalController.GerarConteudoCSV();
                        File.WriteAllText(saveFileDialog.FileName, conteudoCsv, Encoding.UTF8);

                        MessageBox.Show("Ficheiro CSV exportado e guardado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTerminarSessao_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Tem a certeza que deseja terminar a sessão atual?",
                                             "Terminar Sessão",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Sessao.UtilizadorAtual = string.Empty;

                this.Hide();

                FormLogin novoLogin = new FormLogin();

                if (novoLogin.ShowDialog() == DialogResult.OK)
                {
                    this.FormPrincipal_Load(this, EventArgs.Empty);

                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LimparCamposTexto(Control pai)
        {
            foreach (Control c in pai.Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)c).Text = string.Empty;
                }
                if (c.HasChildren)
                {
                    LimparCamposTexto(c);
                }
            }
        }
    }
}