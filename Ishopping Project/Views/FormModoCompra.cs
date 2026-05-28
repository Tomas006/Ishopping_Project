using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IShopping.Controllers;
using IShopping.Models;

namespace Ishopping_Project.Views
{
    public partial class FormModoCompra : Form
    {
        private Compra _compraAtiva;
        private decimal _orcamentoMensal = 0;
        private BindingList<ItemCompra> _itensGrelha;

        public FormModoCompra()
        {
            InitializeComponent();

            dataGridViewLista.AutoGenerateColumns = false;
            dataGridViewLista.CellFormatting += DataGridViewLista_CellFormatting;

            // Eventos para controlar o clique em tempo real na checkbox da grelha
            dataGridViewLista.CurrentCellDirtyStateChanged += DataGridViewLista_CurrentCellDirtyStateChanged;
            dataGridViewLista.CellValueChanged += DataGridViewLista_CellValueChanged;
        }

        public FormModoCompra(int compraId) : this()
        {
            _compraAtiva = FormModoCompraController.ObterCompraParaProcessar(compraId);

            if (_compraAtiva == null)
            {
                MessageBox.Show("Erro ao carregar a compra ou a mesma já não se encontra disponível.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            // REQUISITO: Se a lista já foi FECHADA, entra estritamente em modo de leitura
            if (_compraAtiva.Estado != null && _compraAtiva.Estado.ToUpper() == "FECHADA")
            {
                ConfigurarModoApenasLeitura();
                MessageBox.Show("Esta lista encontra-se FECHADA. Os dados foram carregados apenas para leitura.", 
                    "Lista Fechada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // REQUISITO 19: Transição AUTOMÁTICA de estado ao entrar no ecrã de execução da compra
                try
                {
                    int utilizadorId = Sessao.UtilizadorAtualObj?.Id ?? 1;
                    _compraAtiva.Estado = "EM COMPRA";
                    _compraAtiva.AlteradoPorId = utilizadorId;
                    _compraAtiva.DataAlteracao = DateTime.Now;

                    // Persiste a mudança de estado imediatamente na BD via controlador
                    FormModoCompraController.AtualizarEstadoCompra(_compraAtiva);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Aviso ao atualizar estado da compra para processamento: " + ex.Message, 
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            _orcamentoMensal = FormModoCompraController.ObterOrcamentoDoMes(DateTime.Now.Month, DateTime.Now.Year);

            ConfigurarGrelhaModoCompra();
            PreencherComboTipos();
            AtualizarInterface();
        }

        private void FormModoCompra_Load(object sender, EventArgs e)
        {
            // Foco inicial num controlo neutro ou útil do utilizador
            comboBoxTipo.Focus();
        }

        private void ConfigurarGrelhaModoCompra()
        {
            dataGridViewLista.Columns.Clear();

            // 1. Checkbox de Adquirido
            dataGridViewLista.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "AdquiridoCol",
                DataPropertyName = "Adquirido",
                HeaderText = "No Caminho?", 
                Width = 90,
                ReadOnly = false
            });

            // 2. ID do Item
            dataGridViewLista.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50,
                ReadOnly = true
            });

            // 3. Nome do Artigo
            dataGridViewLista.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome", // Vinculado à propriedade de exibição do ItemCompra/Artigo
                HeaderText = "Artigo",
                Width = 180,
                ReadOnly = true
            });

            // 4. Quantidade Comprada
            dataGridViewLista.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "QuantidadeComprada",
                HeaderText = "Qtd",
                Width = 60,
                ReadOnly = true
            });

            // 5. Preço Unitário
            dataGridViewLista.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecoUnitarioCol",
                HeaderText = "Preço Unit.",
                Width = 90,
                ReadOnly = true
            });

            // 6. Total Calculado (Qtd * Preço)
            dataGridViewLista.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalCol",
                HeaderText = "Total Item",
                Width = 100,
                ReadOnly = true
            });
        }

        private void DataGridViewLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewLista.IsCurrentCellDirty && dataGridViewLista.CurrentCell is DataGridViewCheckBoxCell)
            {
                dataGridViewLista.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridViewLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewLista.Columns[e.ColumnIndex].Name == "AdquiridoCol")
            {
                var row = dataGridViewLista.Rows[e.RowIndex];
                if (row.DataBoundItem is ItemCompra item)
                {
                    int utilizadorId = Sessao.UtilizadorAtualObj?.Id ?? 1;

                    // Atualiza a propriedade local explicitamente para forçar o recálculo correto antes de ir à BD
                    item.Adquirido = (bool)row.Cells["AdquiridoCol"].Value;

                    // Grava imediatamente a alteração do clique na BD para salvaguardar os dados contra quebras de energia
                    FormModoCompraController.MarcarItemComoAdquirido(item.Id, item.QuantidadeComprada, item.PrecoUnitario, utilizadorId);
                }

                RecalcularTotaisInterface();
            }
        }

        private void RecalcularTotaisInterface()
        {
            if (_itensGrelha == null) return;

            // 1. Contagem total baseada em TODOS os itens ativos na compra
            int totalItens = _itensGrelha.Count;
            int adquiridos = _itensGrelha.Count(i => i.Adquirido);

            // 2. Atualizar a ProgressBar com segurança
            progressBarItensPrevistos.Minimum = 0;
            progressBarItensPrevistos.Maximum = totalItens > 0 ? totalItens : 1;

            if (adquiridos > progressBarItensPrevistos.Maximum)
                progressBarItensPrevistos.Maximum = adquiridos;

            progressBarItensPrevistos.Value = adquiridos;

            // 3. Atualizar a Label de progresso textual
            labellProgressoItens.Text = $"{adquiridos} de {totalItens}";

            // 4. Cálculos Financeiros (Apenas o que está de facto selecionado no carrinho real)
            decimal totalCarrinho = _itensGrelha
                .Where(i => i.Adquirido)
                .Sum(i => i.QuantidadeComprada * i.PrecoUnitario);

            decimal disponivel = _orcamentoMensal - totalCarrinho;

            labelOrcamentoMensal.Text = $"{_orcamentoMensal:N2} €";
            labelTotalCarrinho.Text = $"{totalCarrinho:N2} €";
            labelOrcamentoDisponivel.Text = $"{disponivel:N2} €";

            // Exibe a label com o estado atualizado no cabeçalho do ecrã
            if (labelEstadoAtual != null) labelEstadoAtual.Text = _compraAtiva.Estado;

            // 5. Alerta visual do Painel de Orçamento Excedido
            if (totalCarrinho > _orcamentoMensal)
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Red;
                if (panelAviso != null) panelAviso.Visible = true;
            }
            else
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.SystemColors.ControlText;
                if (panelAviso != null) panelAviso.Visible = false;
            }
        }

        private void DataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewLista.Rows[e.RowIndex];
            if (row.DataBoundItem is ItemCompra item)
            {
                string nomeColuna = dataGridViewLista.Columns[e.ColumnIndex].Name;

                if (nomeColuna == "PrecoUnitarioCol")
                {
                    e.Value = $"{item.PrecoUnitario:N2} €";
                    e.FormattingApplied = true;
                }
                else if (nomeColuna == "TotalCol")
                {
                    decimal subtotal = item.QuantidadeComprada * item.PrecoUnitario;
                    e.Value = $"{subtotal:N2} €";
                    e.FormattingApplied = true;
                }
            }
        }

        private void AtualizarInterface()
        {
            if (_compraAtiva == null) return;

            _compraAtiva = FormModoCompraController.ObterCompraParaProcessar(_compraAtiva.Id);
            if (_compraAtiva == null) return;

            _itensGrelha = new BindingList<ItemCompra>(_compraAtiva.Itens.ToList());
            dataGridViewLista.DataSource = _itensGrelha;

            RecalcularTotaisInterface();
        }

        private void PreencherComboTipos()
        {
            comboBoxTipo.DataSource = FormModoCompraController.ObterTiposArtigo();
            comboBoxTipo.DisplayMember = "Nome";
            comboBoxTipo.ValueMember = "Id";
            comboBoxTipo.SelectedIndex = -1;
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedValue is int tipoId)
            {
                comboBoxArtigo.DataSource = FormModoCompraController.ObterArtigosPorTipo(tipoId);
                comboBoxArtigo.DisplayMember = "Nome";
                comboBoxArtigo.ValueMember = "Id";
                comboBoxArtigo.SelectedIndex = -1;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (comboBoxArtigo.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione um artigo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDownQtd.Value <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior do que zero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var artigoSelecionado = (Artigo)comboBoxArtigo.SelectedItem;
            int utilizadorId = Sessao.UtilizadorAtualObj?.Id ?? 1;
            decimal precoArtigo = artigoSelecionado?.Preco ?? 0;

            bool ok = FormModoCompraController.AdicionarItemNaoPrevisto(
                _compraAtiva.Id,
                (int)comboBoxArtigo.SelectedValue,
                artigoSelecionado?.Nome ?? "Artigo Extra",
                (int)numericUpDownQtd.Value,
                precoArtigo,
                textBoxObservacoes.Text,
                utilizadorId
            );

            if (ok)
            {
                numericUpDownQtd.Value = 1;
                textBoxObservacoes.Clear();
                comboBoxArtigo.SelectedIndex = -1;
                comboBoxTipo.SelectedIndex = -1;
                AtualizarInterface();
            }
            else
            {
                MessageBox.Show("Erro ao adicionar o artigo. Verifica se o ID do Artigo ou Utilizador existem na BD.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimparCarrinho_Click(object sender, EventArgs e)
        {
            var opc = MessageBox.Show("Deseja desmarcar todos os itens e remover os artigos extras adicionados nesta compra?",
                "Limpar Carrinho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opc == DialogResult.Yes)
            {
                int utilizadorId = Sessao.UtilizadorAtualObj?.Id ?? 1;

                // Executa a limpeza delegando a responsabilidade ao Controller (mantendo isolamento de camadas)
                bool limpoComSucesso = FormModoCompraController.LimparCarrinhoEExtras(_compraAtiva.Id, utilizadorId);

                if (limpoComSucesso)
                {
                    AtualizarInterface();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao redefinir os dados do carrinho.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            var opc = MessageBox.Show("Deseja finalizar e fechar esta compra? Esta ação é definitiva e trancará os dados.",
                "Finalizar Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opc == DialogResult.Yes)
            {
                int utilizadorId = Sessao.UtilizadorAtualObj?.Id ?? 1;

                // Garante a submissão de edições pendentes na UI antes de salvar
                dataGridViewLista.EndEdit();

                // Chama o fecho e internamente o controller muda o estado para "FECHADA" e tranca as variáveis
                if (FormModoCompraController.FecharCompra(_compraAtiva.Id, utilizadorId))
                {
                    MessageBox.Show("Compra FECHADA com sucesso! Os dados foram guardados e arquivados.", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao fechar a compra na Base de Dados.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigurarModoApenasLeitura()
        {
            // Tranca os controlos visuais de mutação de dados para obedecer à Regra 13 e 19
            dataGridViewLista.ReadOnly = true;
            comboBoxTipo.Enabled = false;
            comboBoxArtigo.Enabled = false;
            numericUpDownQtd.Enabled = false;
            textBoxObservacoes.ReadOnly = true;
            
            btnAdicionar.Enabled = false;
            btnLimparCarrinho.Enabled = false;
            btnFinalizarCompra.Enabled = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}