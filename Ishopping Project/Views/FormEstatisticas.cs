using IShopping.Controllers;
using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace IShopping.Views
{
    public partial class FormEstatisticas : Form
    {
        public FormEstatisticas()
        {
            InitializeComponent();
        }

        private void FormEstatisticas_Load(object sender, EventArgs e)
        {
            
           

            CarregarDadosEstatisticas();
        }

        private void CarregarDadosEstatisticas()
        {
            try
            {
              
                var resumo = FormEstatisticasController.ObterResumoGeral();
                labelTotalGasto.Text = resumo.totalGasto.ToString("C2");
                labelListasConcluidas.Text = resumo.listasFechadas.ToString();
                labelMediaOrcamentos.Text = resumo.mediaOrcamentos.ToString("C2");

               
                dataGridViewListas.DataSource = FormEstatisticasController.ObterHistoricoGlobal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados estatísticos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}