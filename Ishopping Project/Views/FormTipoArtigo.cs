using Ishopping_Project.Controlleres;
using IShopping.Models;
using System;
using System.Windows.Forms;

namespace Ishopping_Project.Views
{
    public partial class FormTipoArtigo : Form
    {
        // Variável global para controlar o ID do tipo selecionado
        private int idTipoSelecionado = 0;

        public FormTipoArtigo()
        {
            InitializeComponent();

            // LIGAÇÃO MANUAL FORÇADA: Para garantir que o C# escuta o evento,
            // mesmo que o Designer do Visual Studio tenha limpado a associação.
            dataGridViewTiposArtigos.SelectionChanged += dataGridViewTiposArtigos_SelectionChanged;
        }

        private void AtualizarGrelha()
        {
            // 1. Desliga temporariamente o evento para não estragar a limpeza
            dataGridViewTiposArtigos.SelectionChanged -= dataGridViewTiposArtigos_SelectionChanged;

            // 2. Atualiza os dados vindo do Controlador
            dataGridViewTiposArtigos.DataSource = null;
            dataGridViewTiposArtigos.DataSource = FormTipoArtigoController.ObterTodosTipos();

            // 3. Remove qualquer seleção automática que o Windows Forms tente fazer
            dataGridViewTiposArtigos.ClearSelection();
            if (dataGridViewTiposArtigos.CurrentRow != null)
            {
                dataGridViewTiposArtigos.CurrentRow.Selected = false;
            }

            // 4. Volta a ligar o evento para os cliques futuros do utilizador
            dataGridViewTiposArtigos.SelectionChanged += dataGridViewTiposArtigos_SelectionChanged;

            // 5. Garante que os campos começam totalmente limpos para um novo registo!
            limparCampos();
        }

        private void FormTipoArtigo_Load(object sender, EventArgs e)
        {
            AtualizarGrelha();
            btnAtualizar.Enabled = false; // Começa bloqueado porque nada está selecionado
           limparCampos();
        }

        // EVENTO DE SELEÇÃO DA TABELA
        private void dataGridViewTiposArtigos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Se houver uma linha ativa e selecionada
                if (dataGridViewTiposArtigos.CurrentRow != null && dataGridViewTiposArtigos.CurrentRow.Selected)
                {
                    var linhaAtual = dataGridViewTiposArtigos.CurrentRow;

                    if (linhaAtual.Cells["Id"].Value != null && linhaAtual.Cells["Nome"].Value != null)
                    {
                        // Guarda o ID e mete o texto na caixa
                        idTipoSelecionado = Convert.ToInt32(linhaAtual.Cells["Id"].Value);
                        textBoxNomeTipoArtigo.Text = linhaAtual.Cells["Nome"].Value.ToString();

                        // Ajusta os botões para modo de Edição/Atualização
                        btnAtualizar.Enabled = true;
                        btnGravarTipoArtigo.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na seleção: " + ex.Message);
            }
        }

        // BOTÃO: Gravar (Novo Registo)
        private void btnGravarTipoArtigo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeTipoArtigo.Text))
            {
                MessageBox.Show("O nome do tipo de artigo é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mensagem;
            bool ok = FormTipoArtigoController.CriarTipoArtigo(textBoxNomeTipoArtigo.Text.Trim(), out mensagem);

            if (ok)
            {
                MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                AtualizarGrelha();
            }
            else
            {
                MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÃO: Atualizar (Editar Registo existente)
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (idTipoSelecionado == 0) return;

            string mensagem;
            bool ok = FormTipoArtigoController.AtualizarTipoArtigo(idTipoSelecionado, textBoxNomeTipoArtigo.Text.Trim(), out mensagem);

            if (ok)
            {
                MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                AtualizarGrelha();
            }
            else
            {
                MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÃO: Apagar
        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dataGridViewTiposArtigos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um tipo de artigo na tabela para apagar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Tem certeza de que deseja apagar o tipo de artigo selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string mensagem;
                int id = Convert.ToInt32(dataGridViewTiposArtigos.CurrentRow.Cells["Id"].Value);

                bool ok = FormTipoArtigoController.ApagarTipoArtigo(id, out mensagem);

                if (ok)
                {
                    MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limparCampos();
                    AtualizarGrelha();
                }
                else
                {
                    MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            textBoxNomeTipoArtigo.Clear();
            idTipoSelecionado = 0;
            btnGravarTipoArtigo.Enabled = true;
            btnAtualizar.Enabled = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}