using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IShopping.Controllers;
using IShopping.Models;

namespace Ishopping_Project.Views
{
    public partial class FormPlanearLista : Form
    {
        // Carrinho temporário em memória RAM ligado à DataSource da Grelha
        private BindingList<ItemPrevisto> _carrinhoEmMemoria = new BindingList<ItemPrevisto>();

        // DICIONÁRIO DE SEGURANÇA: Guarda a relação (ArtigoID -> Nome do Tipo)
        private Dictionary<int, string> _cacheTiposArtigos = new Dictionary<int, string>();

        // ID do utilizador ativo no sistema
        private int idUtilizadorLogado = 1;
        private int _compraIdAtual = 0;

        // 1. Construtor Padrão (Usado para Nova Lista)
        public FormPlanearLista()
        {
            InitializeComponent();
            InicializarConfiguracoesBase();

            // Define o comportamento inicial para nova lista diretamente aqui
            textBoxDataCriacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            textBoxDataCriacao.ReadOnly = true;

            // Uma nova lista começa estritamente como "PLANEADA" e o utilizador não deve alterar à mão
            comboBoxEstado.SelectedIndex = 0;
            comboBoxEstado.Enabled = false;

            AtualizarOrcamentoETotais();
        }

        // 2. Construtor com ID (Usado para Carregar Lista Existente)
        public FormPlanearLista(int compraId)
        {
            InitializeComponent();
            _compraIdAtual = compraId;

            InicializarConfiguracoesBase();
            CarregarDadosDaListaExistente(_compraIdAtual);
        }

        // Centraliza a configuração inicial para evitar código duplicado
        private void InicializarConfiguracoesBase()
        {
            dataGridViewLinhas.AutoGenerateColumns = false;
            dataGridViewLinhas.DataSource = _carrinhoEmMemoria;
            dataGridViewLinhas.CellFormatting += DataGridViewLinhas_CellFormatting;

            // Carrega os estados possíveis na ComboBox
            comboBoxEstado.Items.Clear();
            comboBoxEstado.Items.AddRange(new string[] { "PLANEADA", "EM COMPRA", "FECHADA" });
            comboBoxEstado.SelectedIndex = 0;

            // Carrega os artigos da BD e mapeia o cache de tipos
            CarregarComboArtigos();
            ConfigurarGrelha();
        }

        private void FormPlanearLista_Load(object sender, EventArgs e)
        {
            comboBoxArtigos.Focus();
        }

        // Carrega os dados da lista e valida se está FECHADA para aplicar o modo ReadOnly
        private void CarregarDadosDaListaExistente(int id)
        {
            try
            {
                var compra = FormPlanearListaController.ObterCompraCompletaParaPlaneamento(id);

                if (compra != null)
                {
                    textBoxDataCriacao.Text = compra.DataCriacao.ToString("dd/MM/yyyy");
                    textBoxDataCriacao.ReadOnly = true;

                    // Mapeamento dinâmico e seguro da string vinda do modelo para o index da Combo
                    if (!string.IsNullOrEmpty(compra.Estado))
                    {
                        int indexEstado = comboBoxEstado.Items.IndexOf(compra.Estado.ToUpper());
                        comboBoxEstado.SelectedIndex = indexEstado >= 0 ? indexEstado : 0;
                    }
                    else
                    {
                        comboBoxEstado.SelectedIndex = 0;
                    }

                    // Por segurança do fluxo, a ComboBox fica desativada para edição manual direta neste ecrã
                    comboBoxEstado.Enabled = false;

                    _carrinhoEmMemoria.Clear();
                    foreach (var item in compra.Itens)
                    {
                        var itemPrevisto = new ItemPrevisto
                        {
                            ArtigoId = item.ArtigoId,
                            QuantidadePrevista = item.QuantidadeComprada, // Se o modelo usar QuantidadePrevista, altera aqui
                            Artigo = item.Artigo
                        };
                        _carrinhoEmMemoria.Add(itemPrevisto);

                        string nomeTipo = (item.Artigo != null && item.Artigo.TipoArtigo != null) ? item.Artigo.TipoArtigo.Nome : "Geral";
                        _cacheTiposArtigos[item.ArtigoId] = nomeTipo;
                    }

                    AtualizarOrcamentoETotais();

                    // REQUISITO 13 e 22 (g): Se a compra já estiver "FECHADA", bloqueia as ações do ecrã (Apenas Leitura)
                    if (compra.Estado != null && compra.Estado.ToUpper() == "FECHADA")
                    {
                        ConfigurarModoApenasLeitura(true);
                        MessageBox.Show("Esta lista encontra-se FECHADA. Os dados foram carregados apenas para leitura.", "Lista Fechada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ConfigurarModoApenasLeitura(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados da lista selecionada: " + ex.Message, "Erro de Ligação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ativa ou desativa os controlos dependendo do estado da lista
        private void ConfigurarModoApenasLeitura(bool apenasLeitura)
        {
            bool ativaControlos = !apenasLeitura;

            comboBoxArtigos.Enabled = ativaControlos;
            numericUpDownQuantidadePlaneada.Enabled = ativaControlos;
            btnAdicionarArtigo.Enabled = ativaControlos;
            btnRemoverArtigo.Enabled = ativaControlos;
            btnGuardar.Enabled = ativaControlos;
            btnLimpar.Enabled = ativaControlos;

            // A tabela pode ficar visível para consulta, mas bloqueia interações directas se necessário
            dataGridViewLinhas.ReadOnly = apenasLeitura;
        }

        private void CarregarComboArtigos()
        {
            try
            {
                var artigos = FormPlanearListaController.ObterArtigos();
                _cacheTiposArtigos.Clear();

                if (artigos != null)
                {
                    foreach (var art in artigos)
                    {
                        string nomeTipo = (art.TipoArtigo != null) ? art.TipoArtigo.Nome : "Geral";
                        _cacheTiposArtigos[art.Id] = nomeTipo;
                    }
                }

                comboBoxArtigos.DataSource = artigos;
                comboBoxArtigos.ValueMember = "Id";
                comboBoxArtigos.DisplayMember = "Nome";
                comboBoxArtigos.SelectedIndex = -1;

                comboBoxArtigos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxArtigos.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os artigos da Base de Dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrelha()
        {
            dataGridViewLinhas.Columns.Clear();
            dataGridViewLinhas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ArtigoId", HeaderText = "Artigo ID", Width = 75, ReadOnly = true });
            dataGridViewLinhas.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeArtigo", HeaderText = "Artigo", Width = 120, ReadOnly = true });
            dataGridViewLinhas.Columns.Add(new DataGridViewTextBoxColumn { Name = "TipoArtigo", HeaderText = "Tipo", Width = 100, ReadOnly = true });
            dataGridViewLinhas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QuantidadePrevista", HeaderText = "Qtd. Prevista", Width = 95, ReadOnly = true });
            dataGridViewLinhas.Columns.Add(new DataGridViewTextBoxColumn { Name = "PrecoUnitario", HeaderText = "Preço Unit.", Width = 90, ReadOnly = true });
            dataGridViewLinhas.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalLinha", HeaderText = "Total Item", Width = 100, ReadOnly = true });
        }

        private void DataGridViewLinhas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewLinhas.Rows[e.RowIndex];
                var item = (ItemPrevisto)row.DataBoundItem;

                if (item != null)
                {
                    string nomeColuna = dataGridViewLinhas.Columns[e.ColumnIndex].Name;

                    if (nomeColuna == "NomeArtigo")
                    {
                        e.Value = item.Artigo != null ? item.Artigo.Nome : "Artigo Desconhecido";
                    }
                    else if (nomeColuna == "TipoArtigo")
                    {
                        e.Value = _cacheTiposArtigos.ContainsKey(item.ArtigoId) ? _cacheTiposArtigos[item.ArtigoId] : "Geral";
                    }
                    else if (nomeColuna == "PrecoUnitario")
                    {
                        decimal preco = item.Artigo != null ? item.Artigo.Preco : 0;
                        e.Value = $"{preco:N2} €";
                    }
                    else if (nomeColuna == "TotalLinha")
                    {
                        decimal preco = item.Artigo != null ? item.Artigo.Preco : 0;
                        e.Value = $"{item.QuantidadePrevista * preco:N2} €";
                    }
                }
            }
        }

        private void AtualizarOrcamentoETotais()
        {
            decimal orcamento = FormPlanearListaController.ObterOrcamentoAtual();
            labelOrcamentoMesAtual.Text = orcamento > 0 ? $"{orcamento:N2} €" : "0,00 €";

            decimal totalDinheiroLista = _carrinhoEmMemoria.Where(i => i.Artigo != null).Sum(i => i.QuantidadePrevista * i.Artigo.Preco);
            labelTotalPlaneado.Text = $"{totalDinheiroLista:N2} €";

            labelTotalPlaneado.ForeColor = (totalDinheiroLista > orcamento && orcamento > 0) ? Color.Red : SystemColors.ControlText;
        }

        private void btnAdicionarArtigo_Click(object sender, EventArgs e)
        {
            if (comboBoxArtigos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleciona um artigo válido da lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDownQuantidadePlaneada.Value <= 0)
            {
                MessageBox.Show("A quantidade planeada deve ser no mínimo 1.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Artigo artigo = (Artigo)comboBoxArtigos.SelectedItem;
            int qtd = Convert.ToInt32(numericUpDownQuantidadePlaneada.Value);

            var existente = _carrinhoEmMemoria.FirstOrDefault(i => i.ArtigoId == artigo.Id);

            if (existente != null)
            {
                existente.QuantidadePrevista += qtd;
                _carrinhoEmMemoria.ResetBindings();
            }
            else
            {
                _carrinhoEmMemoria.Add(new ItemPrevisto
                {
                    ArtigoId = artigo.Id,
                    Artigo = artigo,
                    QuantidadePrevista = qtd
                });
            }

            comboBoxArtigos.SelectedIndex = -1;
            numericUpDownQuantidadePlaneada.Value = 1;

            AtualizarOrcamentoETotais();
            comboBoxArtigos.Focus();
        }

        private void btnRemoverArtigo_Click(object sender, EventArgs e)
        {
            if (dataGridViewLinhas.CurrentRow != null && dataGridViewLinhas.CurrentRow.Index >= 0)
            {
                var item = (ItemPrevisto)dataGridViewLinhas.CurrentRow.DataBoundItem;
                if (item != null)
                {
                    _carrinhoEmMemoria.Remove(item);
                    AtualizarOrcamentoETotais();
                }
            }
            else
            {
                MessageBox.Show("Seleciona uma linha na tabela para remover o artigo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_carrinhoEmMemoria.Count == 0)
            {
                MessageBox.Show("Adiciona pelo menos um artigo antes de guardar a lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomeLista = $"Planeamento - {DateTime.Now:dd/MM/yyyy}";
            var listaItens = _carrinhoEmMemoria.ToList();
            string resultado = "";

            if (_compraIdAtual > 0)
            {
                resultado = FormPlanearListaController.AtualizarPlaneamento(_compraIdAtual, listaItens, idUtilizadorLogado);
            }
            else
            {
                resultado = FormPlanearListaController.GravarPlaneamento(nomeLista, listaItens, idUtilizadorLogado);
            }

            if (resultado == "Sucesso")
            {
                MessageBox.Show("Lista de compras guardada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLimpar_Click(null, null);
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado, "Erro ao guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            _carrinhoEmMemoria.Clear();
            _compraIdAtual = 0;
            comboBoxArtigos.SelectedIndex = -1;
            numericUpDownQuantidadePlaneada.Value = 1;

            // Ao limpar, garante que o ecrã volta ao estado nativo editável "PLANEADA"
            comboBoxEstado.SelectedIndex = 0;
            ConfigurarModoApenasLeitura(false);

            AtualizarOrcamentoETotais();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonListaExistente_Click(object sender, EventArgs e)
        {
            try
            {
                var listasAbertas = FormPlanearListaController.ObterListasPlaneadasEmAberto();

                if (listasAbertas == null || listasAbertas.Count == 0)
                {
                    MessageBox.Show("Não existem listas em aberto de momento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var formEscolherLista = new FormEscolherListaExistente(listasAbertas))
                {
                    var resultado = formEscolherLista.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        _compraIdAtual = formEscolherLista.CompraIdSelecionada;
                        CarregarDadosDaListaExistente(_compraIdAtual);
                    }
                    else if (resultado == DialogResult.Yes)
                    {
                        _compraIdAtual = 0;
                        btnLimpar_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar a lista: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}