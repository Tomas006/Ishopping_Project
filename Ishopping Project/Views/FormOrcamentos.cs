using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IShopping.Controllers;
using IShopping.Models;

namespace Ishopping_Project.Views
{
    public partial class FormOrcamentos : Form
    {
        private int idOrcamentoSelecionado = 0;
        private int idUtilizadorLogado => Sessao.UtilizadorAtualObj?.Id ?? 1; 

        public FormOrcamentos()
        {
            InitializeComponent();
        }

        private void FormOrcamentos_Load(object sender, EventArgs e)
        {
            PreencherComboBoxes();
            AtualizarGrelha();
        }

        

        private void PreencherComboBoxes()
        {
            comboBoxMes.Items.Clear();

            
            var meses = Enumerable.Range(1, 12).Select(i => new
            {
                Numero = i,
                Nome = CultureInfo.GetCultureInfo("pt-PT").DateTimeFormat.GetMonthName(i).ToUpper()
            }).ToList();

            comboBoxMes.DataSource = meses;
            comboBoxMes.ValueMember = "Numero"; 
            comboBoxMes.DisplayMember = "Nome";  

           
            comboBoxAno.Items.Clear();
            int anoAtual = DateTime.Now.Year;
            for (int i = anoAtual; i <= anoAtual + 5; i++)
            {
                comboBoxAno.Items.Add(i);
            }

            comboBoxMes.SelectedValue = DateTime.Now.Month;
            comboBoxAno.SelectedItem = DateTime.Now.Year;
        }

        private void AtualizarGrelha()
        {
            dataGridViewOrcamentos.SelectionChanged -= dataGridViewOrcamentos_SelectionChanged;

            dataGridViewOrcamentos.AutoGenerateColumns = true;
            dataGridViewOrcamentos.DataSource = null;
            dataGridViewOrcamentos.DataSource = FormOrcamentoController.ObterTodosOrcamentos();

           
            if (dataGridViewOrcamentos.Columns["Id"] != null)
            {
                dataGridViewOrcamentos.Columns["Id"].HeaderText = "ID";
                dataGridViewOrcamentos.Columns["Id"].Width = 50;
            }

            if (dataGridViewOrcamentos.Columns["Mes"] != null)
            {
                dataGridViewOrcamentos.Columns["Mes"].HeaderText = "Mês";
                dataGridViewOrcamentos.Columns["Mes"].Width = 80;
            }

            if (dataGridViewOrcamentos.Columns["Ano"] != null)
            {
                dataGridViewOrcamentos.Columns["Ano"].HeaderText = "Ano";
                dataGridViewOrcamentos.Columns["Ano"].Width = 70;
            }

            if (dataGridViewOrcamentos.Columns["ValorMaximo"] != null)
            {
                dataGridViewOrcamentos.Columns["ValorMaximo"].HeaderText = "Valor Limite (€)";
                dataGridViewOrcamentos.Columns["ValorMaximo"].DefaultCellStyle.Format = "N2";
                dataGridViewOrcamentos.Columns["ValorMaximo"].Width = 110;
            }

            if (dataGridViewOrcamentos.Columns["CriadoPorId"] != null) dataGridViewOrcamentos.Columns["CriadoPorId"].Visible = false;
            if (dataGridViewOrcamentos.Columns["AlteradoPorId"] != null) dataGridViewOrcamentos.Columns["AlteradoPorId"].Visible = false;

            if (dataGridViewOrcamentos.Columns["CriadoPor"] != null) dataGridViewOrcamentos.Columns["CriadoPor"].HeaderText = "Criado por";
            if (dataGridViewOrcamentos.Columns["AlteradoPor"] != null) dataGridViewOrcamentos.Columns["AlteradoPor"].HeaderText = "Alterado por";

           
          
            dataGridViewOrcamentos.CellFormatting += (sender, e) =>
            {
               
                if ((dataGridViewOrcamentos.Columns[e.ColumnIndex].Name == "CriadoPor" ||
                     dataGridViewOrcamentos.Columns[e.ColumnIndex].Name == "AlteradoPor") && e.Value != null)
                {
                    if (e.Value is Utilizador user) e.Value = user.Username;
                }

               
                if (dataGridViewOrcamentos.Columns[e.ColumnIndex].Name == "Mes" && e.Value != null)
                {
                   
                    if (e.Value is int numMes)
                    {
                        e.Value = CultureInfo.GetCultureInfo("pt-PT").DateTimeFormat.GetMonthName(numMes).ToUpper();
                    }
                }
            };

            dataGridViewOrcamentos.ClearSelection();
            if (dataGridViewOrcamentos.CurrentRow != null)
            {
                dataGridViewOrcamentos.CurrentRow.Selected = false;
            }

            dataGridViewOrcamentos.SelectionChanged += dataGridViewOrcamentos_SelectionChanged;
            limparCampos();
        }

        private void limparCampos()
        {
           
            dataGridViewOrcamentos.SelectionChanged -= dataGridViewOrcamentos_SelectionChanged;

            
            this.ActiveControl = btnLimpar;

            
            idOrcamentoSelecionado = 0;
            comboBoxMes.SelectedValue = DateTime.Now.Month;
            comboBoxAno.SelectedItem = DateTime.Now.Year;
            numericUpDownQuantidade.Value = 0;

           
            dataGridViewOrcamentos.CurrentCell = null;

            
            dataGridViewOrcamentos.ClearSelection();

            
            btnGravar.Enabled = true;
            btnAtualizar.Enabled = false;
            btnApagar.Enabled = false;

            comboBoxMes.Enabled = true;
            comboBoxAno.Enabled = true;

            
            dataGridViewOrcamentos.SelectionChanged += dataGridViewOrcamentos_SelectionChanged;
        }

      

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (comboBoxMes.SelectedValue == null || comboBoxAno.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecione o Mês e o Ano.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDownQuantidade.Value <= 0)
            {
                MessageBox.Show("O valor máximo do orçamento deve ser maior que 0.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int mes = Convert.ToInt32(comboBoxMes.SelectedValue);
            int ano = Convert.ToInt32(comboBoxAno.SelectedItem);
            decimal valor = numericUpDownQuantidade.Value;

            string resultado = FormOrcamentoController.GravarOrcamento(mes, ano, valor, idUtilizadorLogado);

            if (resultado == "Sucesso")
            {
                MessageBox.Show("Orçamento gravado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGrelha();
            }
            else
            {
                MessageBox.Show(resultado, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (idOrcamentoSelecionado == 0) return;

            if (numericUpDownQuantidade.Value <= 0)
            {
                MessageBox.Show("O valor máximo do orçamento deve ser maior que 0.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal novoValor = numericUpDownQuantidade.Value;
            string resultado = FormOrcamentoController.AtualizarOrcamento(idOrcamentoSelecionado, novoValor, idUtilizadorLogado);

            if (resultado == "Sucesso")
            {
                MessageBox.Show("Orçamento atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGrelha();
            }
            else
            {
                MessageBox.Show(resultado, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (idOrcamentoSelecionado == 0) return;

            var resposta = MessageBox.Show("Tem a certeza que deseja apagar este orçamento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                if (FormOrcamentoController.ApagarOrcamento(idOrcamentoSelecionado))
                {
                    MessageBox.Show("Orçamento eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarGrelha();
                }
                else
                {
                    MessageBox.Show("Erro ao apagar o orçamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewOrcamentos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrcamentos.CurrentRow != null && dataGridViewOrcamentos.CurrentRow.Index >= 0)
            {
                Orcamento orcamento = (Orcamento)dataGridViewOrcamentos.CurrentRow.DataBoundItem;

                if (orcamento != null)
                {
                    idOrcamentoSelecionado = orcamento.Id;
                    comboBoxMes.SelectedValue = orcamento.Mes; 
                    comboBoxAno.SelectedItem = orcamento.Ano;
                    numericUpDownQuantidade.Value = orcamento.ValorMaximo;

                    comboBoxMes.Enabled = false;
                    comboBoxAno.Enabled = false;

                    btnGravar.Enabled = false;
                    btnAtualizar.Enabled = true;
                    btnApagar.Enabled = true;
                }
            }
        }
    }
}