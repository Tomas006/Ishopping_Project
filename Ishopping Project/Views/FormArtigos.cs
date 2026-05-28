using IShopping.Models;
using Ishopping_Project.Controlleres;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace Ishopping_Project.Views
{
    public partial class FormArtigos : Form
    {
        private int idArtigoSelecionado = 0;

        public FormArtigos()
        {
            InitializeComponent();
            dataGridViewArtigos.SelectionChanged += dataGridViewArtigos_SelectionChanged;
        }

        private void FormArtigos_Load(object sender, EventArgs e)
        {
            CarregarComboBox();
            AtualizarGrelha();
        }

        private void CarregarComboBox()
        {
            try
            {
                comboTipoArtigo.DataSource = FormArtigoController.ObterTiposArtigo();
                comboTipoArtigo.ValueMember = "Id";    
                comboTipoArtigo.DisplayMember = "Nome"; 
                comboTipoArtigo.SelectedIndex = -1;      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarGrelha()
        {
            dataGridViewArtigos.SelectionChanged -= dataGridViewArtigos_SelectionChanged;

           
            if (comboTipoArtigo.SelectedIndex != -1 && idArtigoSelecionado == 0)
            {
                int tipoId = Convert.ToInt32(comboTipoArtigo.SelectedValue);

                
                dataGridViewArtigos.DataSource = FormArtigoController.ObterTodosArtigos()
                                    .Where(a => a.TipoArtigoId == tipoId)
                                    .ToList();
            }
            else
            {
                
                dataGridViewArtigos.DataSource = FormArtigoController.ObterTodosArtigos();
            }

           
            if (dataGridViewArtigos.Columns["TipoArtigoId"] != null)
            {
                dataGridViewArtigos.Columns["TipoArtigoId"].Visible = false;
            }

          
            if (dataGridViewArtigos.Columns["Nome"] != null)
            {
                dataGridViewArtigos.Columns["Nome"].HeaderText = "Nome do Artigo";
            }

           
            if (dataGridViewArtigos.Columns["Preco"] != null)
            {
                dataGridViewArtigos.Columns["Preco"].HeaderText = "Preço (€)";
                dataGridViewArtigos.Columns["Preco"].DefaultCellStyle.Format = "N2"; 
            }

           
            if (dataGridViewArtigos.Columns["TipoArtigo"] != null)
            {
                dataGridViewArtigos.Columns["TipoArtigo"].HeaderText = "Tipo de Artigo";
            }

            
            dataGridViewArtigos.CellFormatting += (sender, e) =>
            {
                if (dataGridViewArtigos.Columns[e.ColumnIndex].Name == "TipoArtigo" && e.Value != null)
                {
                   
                    if (e.Value is TipoArtigo tipo)
                    {
                        e.Value = tipo.Nome;
                    }
                }
            };

            
            dataGridViewArtigos.ClearSelection();
            if (dataGridViewArtigos.CurrentRow != null)
            {
                dataGridViewArtigos.CurrentRow.Selected = false;
            }

            dataGridViewArtigos.SelectionChanged += dataGridViewArtigos_SelectionChanged;
        }

        
        private void dataGridViewArtigos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewArtigos.CurrentRow != null && dataGridViewArtigos.CurrentRow.Selected)
                {
                    var linha = dataGridViewArtigos.CurrentRow;

                   
                    if (linha.Cells["Id"].Value != null)
                    {
                        idArtigoSelecionado = Convert.ToInt32(linha.Cells["Id"].Value);
                        textNome.Text = linha.Cells["Nome"].Value?.ToString();

                        if (linha.Cells["TipoArtigoId"].Value != null)
                        {
                            comboTipoArtigo.SelectedValue = Convert.ToInt32(linha.Cells["TipoArtigoId"].Value);
                        }

                     
                        btnGravar.Enabled = false;
                        btnAtualizar.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao selecionar artigo: " + ex.Message);
            }
        }

        
        private void btnGravar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(textNome.Text) || string.IsNullOrWhiteSpace(textPreco.Text) || comboTipoArtigo.SelectedIndex == -1)
            {
                MessageBox.Show("Todos os campos são obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            
            string precoTexto = textPreco.Text.Trim().Replace(',', '.');

            if (!decimal.TryParse(precoTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precoConvertido))
            {
                MessageBox.Show("Por favor, introduz um preço válido (ex: 1.25)!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

       

            string msg; 


            bool ok = FormArtigoController.CriarArtigo(
                textNome.Text.Trim(),
                precoConvertido,
                Convert.ToInt32(comboTipoArtigo.SelectedValue),
                out msg
            );

            if (ok)
            {
                MessageBox.Show(msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                AtualizarGrelha();
            }
            else
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            
            if (idArtigoSelecionado == 0)
            {
                MessageBox.Show("Por favor, seleciona primeiro um artigo na tabela!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (string.IsNullOrWhiteSpace(textNome.Text) || string.IsNullOrWhiteSpace(textPreco.Text) || comboTipoArtigo.SelectedIndex == -1)
            {
                MessageBox.Show("Nenhum campo pode ficar vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!decimal.TryParse(textPreco.Text.Replace(',', '.'), out decimal precoConvertido))
            {
                MessageBox.Show("Por favor, introduz um preço válido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg; 

            bool ok = FormArtigoController.AtualizarArtigo(
                idArtigoSelecionado,
                textNome.Text.Trim(),
                precoConvertido,
                Convert.ToInt32(comboTipoArtigo.SelectedValue),
                out msg
            );

           
            if (ok)
            {
                MessageBox.Show(msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                AtualizarGrelha();
            }
            else
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (idArtigoSelecionado == 0) return;

            var res = MessageBox.Show("Tens a certeza que queres eliminar este artigo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string msg; 

                if (FormArtigoController.ApagarArtigo(idArtigoSelecionado, out msg))
                {
                    MessageBox.Show(msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limparCampos();
                    AtualizarGrelha();
                }
                else
                {
                    MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

     
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            dataGridViewArtigos.ClearSelection();
        }

        private void limparCampos()
        {
            textNome.Clear();
            comboTipoArtigo.SelectedIndex = -1;
            idArtigoSelecionado = 0;
            textPreco.Clear();

            btnGravar.Enabled = true;
            btnAtualizar.Enabled = false;
        }

      

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}