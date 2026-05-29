using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IShopping.Controllers;

namespace Ishopping_Project.Views
{
    public partial class FormHistoricoListas : Form
    {
        private List<object> _historicoListas = new List<object>();

        public FormHistoricoListas()
        {
            InitializeComponent();
        }

        private void FormHistoricoListas_Load(object sender, EventArgs e)
        {
            dataGridViewListas.AutoGenerateColumns = true;

            try
            {
                _historicoListas = FormHistoricoListasController.ObterTodasAsComprasComCriador();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConfigurarEventosDosFiltros();
            FiltrarGrelha();
        }

        private void ConfigurarEventosDosFiltros()
        {
            radioButtonTodas.CheckedChanged += RadioButtons_CheckedChanged;
            radioButtonPlaneadas.CheckedChanged += RadioButtons_CheckedChanged;
            radioButtonEmCompra.CheckedChanged += RadioButtons_CheckedChanged;
            radioButtonFechadas.CheckedChanged += RadioButtons_CheckedChanged;
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                FiltrarGrelha();
            }
        }

        private void FiltrarGrelha()
        {
            if (_historicoListas == null) return;

            IEnumerable<dynamic> dadosFiltrados = _historicoListas;

            if (radioButtonPlaneadas.Checked)
            {
                dadosFiltrados = dadosFiltrados.Where(c => c.Estado != null && c.Estado.ToUpper() == "PLANEADA");
            }
            else if (radioButtonEmCompra.Checked)
            {
                dadosFiltrados = dadosFiltrados.Where(c => c.Estado != null && c.Estado.ToUpper() == "EM COMPRA");
            }
            else if (radioButtonFechadas.Checked)
            {
                dadosFiltrados = dadosFiltrados.Where(c => c.Estado != null && c.Estado.ToUpper() == "FECHADA");
            }

            dataGridViewListas.DataSource = null;
            dataGridViewListas.DataSource = dadosFiltrados.ToList();

            ConfigurarColunasVisiveis();
        }

        private void ConfigurarColunasVisiveis()
        {
            if (dataGridViewListas.Columns.Count == 0) return;

            string[] colunasParaMostrar = { "IdLista", "NomeLista", "Estado", "DataCriacao", "CriadorNome" };

            foreach (DataGridViewColumn col in dataGridViewListas.Columns)
            {
                if (colunasParaMostrar.Contains(col.Name))
                {
                    col.Visible = true;
                }
                else
                {
                    col.Visible = false;
                }
            }

            if (dataGridViewListas.Columns["IdLista"] != null) dataGridViewListas.Columns["IdLista"].HeaderText = "ID Lista";
            if (dataGridViewListas.Columns["NomeLista"] != null) dataGridViewListas.Columns["NomeLista"].HeaderText = "Nome da Lista";
            if (dataGridViewListas.Columns["Estado"] != null) dataGridViewListas.Columns["Estado"].HeaderText = "Estado";
            if (dataGridViewListas.Columns["DataCriacao"] != null) dataGridViewListas.Columns["DataCriacao"].HeaderText = "Data de Criação";
            if (dataGridViewListas.Columns["CriadorNome"] != null) dataGridViewListas.Columns["CriadorNome"].HeaderText = "Criado Por";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewListas.CurrentRow != null)
            {
                dynamic linhaSelecionada = dataGridViewListas.CurrentRow.DataBoundItem;
                int idLista = linhaSelecionada.IdLista;

                FormPlanearLista formEditar = new FormPlanearLista(idLista);
                this.Hide();
                formEditar.ShowDialog();
                this.Show();

                _historicoListas = FormHistoricoListasController.ObterTodasAsComprasComCriador();
                FiltrarGrelha();
            }
            else
            {
                MessageBox.Show("Por favor, seleciona uma lista da tabela para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}