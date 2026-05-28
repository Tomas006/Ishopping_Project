using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IShopping.Models;

namespace Ishopping_Project.Views
{
    public partial class FormEscolherListaExistente : Form
    {
        // Propriedade para enviar o ID da lista escolhida de volta para o FormPrincipal
        public int CompraIdSelecionada { get; private set; }

        public FormEscolherListaExistente(List<Compra> listasAbertas)
        {
            InitializeComponent();

            comboBoxListas.DropDownStyle = ComboBoxStyle.DropDownList;

            // 1. Lista temporária para preencher a ComboBox
            var itensExibicao = new List<KeyValuePair<int, string>>();

            // 2. Abre o contexto e mapeia ID -> Username
            using (var db = new IShoppingContext())
            {
                var dicionarioUtilizadores = db.Utilizadores
                    .ToDictionary(u => u.Id, u => u.Username);

                // 3. Como CriadoPorId é um int direto, o código fica super curto
                foreach (var compra in listasAbertas)
                {
                    string nomeCriador = "Desconhecido";

                    // Procura diretamente o ID no dicionário
                    if (dicionarioUtilizadores.ContainsKey(compra.CriadoPorId))
                    {
                        nomeCriador = dicionarioUtilizadores[compra.CriadoPorId];
                    }

                    // 🔥 Texto final limpo com o Nome do utilizador
                    string textoFormatado = $"{compra.Nome} (Criado por: {nomeCriador})";

                    itensExibicao.Add(new KeyValuePair<int, string>(compra.Id, textoFormatado));
                }
            }

            // 4. Vincula à ComboBox
            comboBoxListas.DataSource = itensExibicao;
            comboBoxListas.ValueMember = "Key";     // Mantém o ID da Compra original
            comboBoxListas.DisplayMember = "Value"; // Exibe o texto formatado no ecrã
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxListas.SelectedValue is int idSelecionado)
            {
                CompraIdSelecionada = idSelecionado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma lista válida.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}