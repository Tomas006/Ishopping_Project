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
            // Começa com os pontinhos na password por padrão
            textPassword.UseSystemPasswordChar = true;
            AtualizarGrelha();
        }

        private void AtualizarGrelha()
        {
            dataGridViewUtilizadores.SelectionChanged -= dataGridViewUtilizadores_SelectionChanged;

            // MUDA PARA TRUE se queres que as colunas apareçam sozinhas
            dataGridViewUtilizadores.AutoGenerateColumns = true;

            dataGridViewUtilizadores.DataSource = null;
            dataGridViewUtilizadores.DataSource = FormUtilizadorController.ObterTodosUtilizadores();

            dataGridViewUtilizadores.ClearSelection();
            if (dataGridViewUtilizadores.CurrentRow != null)
            {
                dataGridViewUtilizadores.CurrentRow.Selected = false;
            }

            dataGridViewUtilizadores.SelectionChanged += dataGridViewUtilizadores_SelectionChanged;
            limparCampos();
        }

        // EVENTO: Quando selecionas uma linha na tabela (Igual ao Tipos de Artigo)
        private void dataGridViewUtilizadores_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUtilizadores.CurrentRow != null && dataGridViewUtilizadores.CurrentRow.Selected)
                {
                    var linha = dataGridViewUtilizadores.CurrentRow;

                    if (linha.Cells["Id"].Value != null)
                    {
                        // 1. Guarda o ID do utilizador clicado
                        idUtilizadorSelecionado = Convert.ToInt32(linha.Cells["Id"].Value);

                        // 2. AJUSTADO: Mudado de "Nome" para "Name" para bater certo com a tua DataGridView!
                        textNome.Text = linha.Cells["Name"].Value?.ToString();
                        textUsername.Text = linha.Cells["Username"].Value?.ToString();

                        // Fica em branco por segurança (só muda se o utilizador digitar uma nova)
                        textPassword.Clear();

                        // 3. Bloqueia o Gravar e liberta o Atualizar
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

        // BOTÃO: Gravar (Novo Registo)
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

        // BOTÃO: Atualizar (Guardar Alterações do Editar)
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
                AtualizarGrelha(); // Faz o refresh e faz reset aos botões automaticamente
            }
            else
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÃO: Apagar
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

        // CHECKBOX: Ver Password
        private void checkBoxVerPassword_CheckedChanged(object sender, EventArgs e)
        {
            textPassword.UseSystemPasswordChar = !checkBoxVerPassword.Checked;
        }

        // BOTÃO: Limpar (Reseta o estado para poderes criar um Novo)
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

            // Restaura o estado inicial: Gravar ativo, Atualizar bloqueado
            btnGravar.Enabled = true;
            btnAtualizar.Enabled = false;
        }

        // BOTÃO: Voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}