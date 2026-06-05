using IShopping.Controllers;
using System;
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
            CarregarEstatisticas();
        }

        private void CarregarEstatisticas()
        {
            try
            {
                dataGridViewListas.DataSource = FormEstatisticasController.ObterOrcamentoPorMes();
                dataGridView1.DataSource = FormEstatisticasController.ObterPercentivosPorCompra();

                
                dataGridViewListas.CellFormatting += (sender, e) =>
                {
                    if (e.RowIndex >= 0 && dataGridViewListas.Columns[e.ColumnIndex].Name == "Mes" && e.Value != null)
                    {
                        if (e.Value is int numMes)
                        {
                            e.Value = System.Globalization.CultureInfo
                                .GetCultureInfo("pt-PT")
                                .DateTimeFormat
                                .GetMonthName(numMes)
                                .ToUpper();
                            e.FormattingApplied = true;
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar estatísticas: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoltar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGerarSugestoes_Click(object sender, EventArgs e)
        {
            try
            {
                
                decimal sugestao = FormEstatisticasController.SugerirOrcamento();
                textBox1.Text = sugestao > 0
                    ? $"{sugestao:N2} €"
                    : "Sem dados suficientes para sugerir um orçamento.";
                textBox1.ReadOnly = true;

                
                dataGridView2.DataSource = FormEstatisticasController.SugerirListaCompras();

                if (dataGridView2.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Sem histórico de compras nesta semana do mês em meses anteriores para gerar sugestão.",
                        "Sem dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar sugestões: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}