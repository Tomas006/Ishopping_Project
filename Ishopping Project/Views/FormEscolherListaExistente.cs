using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IShopping.Models;

namespace Ishopping_Project.Views
{
    public partial class FormEscolherListaExistente : Form
    {
        public int CompraIdSelecionada { get; private set; }

        public FormEscolherListaExistente(List<Compra> listasAbertas)
        {
            InitializeComponent();

            comboBoxListas.DropDownStyle = ComboBoxStyle.DropDownList;

            var itensExibicao = new List<KeyValuePair<int, string>>();

            using (var db = new IShoppingContext())
            {
                var dicionarioUtilizadores = db.Utilizadores
                    .ToDictionary(u => u.Id, u => u.Name);

                foreach (var compra in listasAbertas)
                {
                    string nomeCriador = "Desconhecido";

                    if (dicionarioUtilizadores.ContainsKey(compra.CriadoPorId))
                    {
                        nomeCriador = dicionarioUtilizadores[compra.CriadoPorId];
                    }

                    string textoFormatado = $"{compra.Nome} (Criado por: {nomeCriador})";

                    itensExibicao.Add(new KeyValuePair<int, string>(compra.Id, textoFormatado));
                }
            }

            comboBoxListas.DataSource = itensExibicao;
            comboBoxListas.ValueMember = "Key";
            comboBoxListas.DisplayMember = "Value";
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