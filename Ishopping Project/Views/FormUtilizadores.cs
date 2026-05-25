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

namespace Ishopping_Project.Views
{
    public partial class FormUtilizadores : Form
    {
        private int idUtilizadorSelecionado = 0;

        public FormUtilizadores()
        {
            InitializeComponent();
            dataGridViewUtilizadores.SelectionChanged += dataGridViewUtilizadores_SelectionChanged;
        }

        private void FormUtilizadores_Load(object sender, EventArgs e)
        {
            
            textPassword.UseSystemPasswordChar = true;
            AtualizarGrelha();
        }

        private void AtualizarGrelha()
        {
            dataGridViewUtilizadores.SelectionChanged -= dataGridViewUtilizadores_SelectionChanged;

           
            dataGridViewUtilizadores.AutoGenerateColumns = true;
            dataGridViewUtilizadores.DataSource = FormUtilizadorController.ObterTodosUtilizadores();

            
            if (dataGridViewUtilizadores.Columns["Id"] != null)
            {
                dataGridViewUtilizadores.Columns["Id"].HeaderText = "ID";
                dataGridViewUtilizadores.Columns["Id"].Width = 60;

           
            if (dataGridViewUtilizadores.Columns["Username"] != null)
            {
                dataGridViewUtilizadores.Columns["Username"].HeaderText = "Nome de Utilizador";
                dataGridViewUtilizadores.Columns["Username"].Width = 180;
            }

            if (dataGridViewUtilizadores.Columns["Password"] != null)
            {
                dataGridViewUtilizadores.Columns["Password"].Visible = false;
            }

            if (dataGridViewUtilizadores.Columns["Compras"] != null)
            {
                dataGridViewUtilizadores.Columns["Compras"].Visible = false;
            }

            
            dataGridViewUtilizadores.ClearSelection();
            if (dataGridViewUtilizadores.CurrentRow != null)
            {
                dataGridViewUtilizadores.CurrentRow.Selected = false;
            }

            dataGridViewUtilizadores.SelectionChanged += dataGridViewUtilizadores_SelectionChanged;

          
            limparCampos();
        }


        private void dataGridViewUtilizadores_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUtilizadores.CurrentRow != null && dataGridViewUtilizadores.CurrentRow.Selected)
                {
                    var linha = dataGridViewUtilizadores.CurrentRow;

                    if (linha.Cells["Id"].Value != null)
                    {
                        
                        idUtilizadorSelecionado = Convert.ToInt32(linha.Cells["Id"].Value);

                       
                        textNome.Text = linha.Cells["Name"].Value?.ToString();
                        textUsername.Text = linha.Cells["Username"].Value?.ToString();

                        
                        textPassword.Clear();

                       
                        btnGravar.Enabled = false;
                        btnAtualizar.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao selecionar: " + ex.Message);
            }
        }

        
        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNome.Text) || string.IsNullOrWhiteSpace(textUsername.Text) || string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Todos os campos são obrigatórios para criar um utilizador!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg;
            bool ok = FormUtilizadorController.CriarUtilizador(
                textNome.Text.Trim(),
                textUsername.Text.Trim(),
                textPassword.Text,
                out msg
            );

            if (ok)
            {
                MessageBox.Show(msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGrelha();
            }
            else
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (idUtilizadorSelecionado == 0) return;

            if (string.IsNullOrWhiteSpace(textNome.Text) || string.IsNullOrWhiteSpace(textUsername.Text))
            {
                MessageBox.Show("Nome e Username não podem ficar vazios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg;
            bool ok = FormUtilizadorController.AtualizarUtilizador(
                idUtilizadorSelecionado,
                textNome.Text.Trim(),
                textUsername.Text.Trim(),
                textPassword.Text,
                out msg
            );

            if (ok)
            {
                MessageBox.Show(msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGrelha(); 
            }
            else
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (idUtilizadorSelecionado == 0) return;

            var res = MessageBox.Show("Tens a certeza que queres eliminar este utilizador?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string msg;
                if (FormUtilizadorController.ApagarUtilizador(idUtilizadorSelecionado, out msg))
                {
                    MessageBox.Show(msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarGrelha();
                }
                else
                {
                    MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void checkBoxVerPassword_CheckedChanged(object sender, EventArgs e)
        {
            textPassword.UseSystemPasswordChar = !checkBoxVerPassword.Checked;
        }

        
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            dataGridViewUtilizadores.ClearSelection();
        }

        private void limparCampos()
        {
            textNome.Clear();
            textUsername.Clear();
            textPassword.Clear();
            idUtilizadorSelecionado = 0;

        
            btnGravar.Enabled = true;
            btnAtualizar.Enabled = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}