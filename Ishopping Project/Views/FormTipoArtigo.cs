using Ishopping_Project.Controlleres;
using IShopping.Models;
using System;
using System.Windows.Forms;

namespace Ishopping_Project.Views
{
    public partial class FormTipoArtigo : Form
    {
        
        private int idTipoSelecionado = 0;

        public FormTipoArtigo()
        {
            InitializeComponent();

            
            dataGridViewTiposArtigos.SelectionChanged += dataGridViewTiposArtigos_SelectionChanged;
        }

        private void AtualizarGrelha()
        {
            dataGridViewTiposArtigos.SelectionChanged -= dataGridViewTiposArtigos_SelectionChanged;

            // 1. Atualizar o DataSource com a lista vinda do teu Controlador de Tipos
            dataGridViewTiposArtigos.DataSource = null;
            dataGridViewTiposArtigos.DataSource = FormTipoArtigoController.ObterTodosTipos();

            // 2. Customizar os Cabeçalhos e limpar a tabela (Estilo Cinema / Artigos!)

            // Mudar o nome da coluna do ID e dar uma largura fixa mais curta
            if (dataGridViewTiposArtigos.Columns["Id"] != null)
            {
                dataGridViewTiposArtigos.Columns["Id"].HeaderText = "ID";
                dataGridViewTiposArtigos.Columns["Id"].Width = 60;
            }

            // Mudar o nome da coluna do Nome do Tipo de Artigo
            if (dataGridViewTiposArtigos.Columns["Nome"] != null)
            {
                dataGridViewTiposArtigos.Columns["Nome"].HeaderText = "Tipo de Artigo";
                dataGridViewTiposArtigos.Columns["Nome"].Width = 200; // Dá espaço para nomes mais longos
            }

            // ESCONDER PROPRIEDADES VIRTUAIS (Super importante no Entity Framework!)
            // Se o teu modelo 'TipoArtigo' tiver uma lista virtual de Artigos (public virtual ICollection<Artigo> Artigos),
            // a DataGridView vai tentar criar uma coluna para ela. Escondemos aqui para não quebrar o layout:
            if (dataGridViewTiposArtigos.Columns["Artigos"] != null)
            {
                dataGridViewTiposArtigos.Columns["Artigos"].Visible = false;
            }

            // 3. Limpar as seleções automáticas da tabela ao carregar
            dataGridViewTiposArtigos.ClearSelection();
            if (dataGridViewTiposArtigos.CurrentRow != null)
            {
                dataGridViewTiposArtigos.CurrentRow.Selected = false;
            }

            dataGridViewTiposArtigos.SelectionChanged += dataGridViewTiposArtigos_SelectionChanged;

            // Executa a tua função para limpar as caixas de texto
            limparCampos();
        }

        private void FormTipoArtigo_Load(object sender, EventArgs e)
        {
            AtualizarGrelha();
            btnAtualizar.Enabled = false; 
            limparCampos();
        }

       

        
        private void dataGridViewTiposArtigos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (dataGridViewTiposArtigos.CurrentRow != null && dataGridViewTiposArtigos.CurrentRow.Selected)
                {
                    var linhaAtual = dataGridViewTiposArtigos.CurrentRow;

                    if (linhaAtual.Cells["Id"].Value != null && linhaAtual.Cells["Nome"].Value != null)
                    {
                        
                        idTipoSelecionado = Convert.ToInt32(linhaAtual.Cells["Id"].Value);
                        textBoxNomeTipoArtigo.Text = linhaAtual.Cells["Nome"].Value.ToString();

                        
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