namespace Ishopping_Project.Views
{
    partial class FormModoCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxObservacoes = new System.Windows.Forms.TextBox();
            this.numericUpDownQtd = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxArtigo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labellProgressoItens = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnLimparCarrinho = new System.Windows.Forms.Button();
            this.btnFinalizarCompra = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.progressBarItensPrevistos = new System.Windows.Forms.ProgressBar();
            this.panelAviso = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.labelOrcamentoDisponivel = new System.Windows.Forms.Label();
            this.labelTotalCarrinho = new System.Windows.Forms.Label();
            this.labelOrcamentoMensal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelEstadoAtual = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQtd)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panelAviso.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewLista);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(664, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Compras Ativas";
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLista.Location = new System.Drawing.Point(8, 23);
            this.dataGridViewLista.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.RowHeadersWidth = 51;
            this.dataGridViewLista.Size = new System.Drawing.Size(636, 298);
            this.dataGridViewLista.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdicionar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxObservacoes);
            this.groupBox2.Controls.Add(this.numericUpDownQtd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBoxArtigo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxTipo);
            this.groupBox2.Location = new System.Drawing.Point(16, 380);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(664, 253);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adicionar Artigo Não Previsto";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.Location = new System.Drawing.Point(485, 167);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(153, 51);
            this.btnAdicionar.TabIndex = 9;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Observações:";
            // 
            // textBoxObservacoes
            // 
            this.textBoxObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxObservacoes.Location = new System.Drawing.Point(21, 160);
            this.textBoxObservacoes.Multiline = true;
            this.textBoxObservacoes.Name = "textBoxObservacoes";
            this.textBoxObservacoes.Size = new System.Drawing.Size(399, 64);
            this.textBoxObservacoes.TabIndex = 7;
            // 
            // numericUpDownQtd
            // 
            this.numericUpDownQtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownQtd.Location = new System.Drawing.Point(503, 74);
            this.numericUpDownQtd.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownQtd.Name = "numericUpDownQtd";
            this.numericUpDownQtd.Size = new System.Drawing.Size(135, 26);
            this.numericUpDownQtd.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(499, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quantidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(233, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Artigo";
            // 
            // comboBoxArtigo
            // 
            this.comboBoxArtigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxArtigo.FormattingEnabled = true;
            this.comboBoxArtigo.Location = new System.Drawing.Point(237, 74);
            this.comboBoxArtigo.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxArtigo.Name = "comboBoxArtigo";
            this.comboBoxArtigo.Size = new System.Drawing.Size(212, 28);
            this.comboBoxArtigo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo Artigo";
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(21, 74);
            this.comboBoxTipo.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(172, 28);
            this.comboBoxTipo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labellProgressoItens);
            this.groupBox3.Controls.Add(this.btnVoltar);
            this.groupBox3.Controls.Add(this.btnLimparCarrinho);
            this.groupBox3.Controls.Add(this.btnFinalizarCompra);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.progressBarItensPrevistos);
            this.groupBox3.Controls.Add(this.panelAviso);
            this.groupBox3.Controls.Add(this.labelOrcamentoDisponivel);
            this.groupBox3.Controls.Add(this.labelTotalCarrinho);
            this.groupBox3.Controls.Add(this.labelOrcamentoMensal);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(727, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 608);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resumo E Controlo FInanceiro";
            // 
            // labellProgressoItens
            // 
            this.labellProgressoItens.AutoSize = true;
            this.labellProgressoItens.Location = new System.Drawing.Point(146, 329);
            this.labellProgressoItens.Name = "labellProgressoItens";
            this.labellProgressoItens.Size = new System.Drawing.Size(23, 16);
            this.labellProgressoItens.TabIndex = 24;
            this.labellProgressoItens.Text = "de";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(21, 542);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(273, 37);
            this.btnVoltar.TabIndex = 23;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnLimparCarrinho
            // 
            this.btnLimparCarrinho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCarrinho.Location = new System.Drawing.Point(21, 481);
            this.btnLimparCarrinho.Name = "btnLimparCarrinho";
            this.btnLimparCarrinho.Size = new System.Drawing.Size(273, 43);
            this.btnLimparCarrinho.TabIndex = 22;
            this.btnLimparCarrinho.Text = "Limpar Carrinho";
            this.btnLimparCarrinho.UseVisualStyleBackColor = true;
            this.btnLimparCarrinho.Click += new System.EventHandler(this.btnLimparCarrinho_Click);
            // 
            // btnFinalizarCompra
            // 
            this.btnFinalizarCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarCompra.Location = new System.Drawing.Point(21, 409);
            this.btnFinalizarCompra.Name = "btnFinalizarCompra";
            this.btnFinalizarCompra.Size = new System.Drawing.Size(273, 55);
            this.btnFinalizarCompra.TabIndex = 10;
            this.btnFinalizarCompra.Text = "Finalizar Compra";
            this.btnFinalizarCompra.UseVisualStyleBackColor = true;
            this.btnFinalizarCompra.Click += new System.EventHandler(this.btnFinalizarCompra_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(17, 291);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(239, 20);
            this.label15.TabIndex = 21;
            this.label15.Text = "Progresso dos Itens Previstos:";
            // 
            // progressBarItensPrevistos
            // 
            this.progressBarItensPrevistos.Location = new System.Drawing.Point(21, 314);
            this.progressBarItensPrevistos.Name = "progressBarItensPrevistos";
            this.progressBarItensPrevistos.Size = new System.Drawing.Size(273, 43);
            this.progressBarItensPrevistos.TabIndex = 17;
            // 
            // panelAviso
            // 
            this.panelAviso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelAviso.Controls.Add(this.label11);
            this.panelAviso.Location = new System.Drawing.Point(21, 194);
            this.panelAviso.Name = "panelAviso";
            this.panelAviso.Size = new System.Drawing.Size(273, 87);
            this.panelAviso.TabIndex = 16;
            this.panelAviso.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(62, 18);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(181, 58);
            this.label11.TabIndex = 17;
            this.label11.Text = "Orçamento \r\nUltrapassado!!";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelOrcamentoDisponivel
            // 
            this.labelOrcamentoDisponivel.AutoSize = true;
            this.labelOrcamentoDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrcamentoDisponivel.Location = new System.Drawing.Point(227, 149);
            this.labelOrcamentoDisponivel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOrcamentoDisponivel.Name = "labelOrcamentoDisponivel";
            this.labelOrcamentoDisponivel.Size = new System.Drawing.Size(49, 20);
            this.labelOrcamentoDisponivel.TabIndex = 15;
            this.labelOrcamentoDisponivel.Text = "label";
            // 
            // labelTotalCarrinho
            // 
            this.labelTotalCarrinho.AutoSize = true;
            this.labelTotalCarrinho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalCarrinho.Location = new System.Drawing.Point(227, 95);
            this.labelTotalCarrinho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotalCarrinho.Name = "labelTotalCarrinho";
            this.labelTotalCarrinho.Size = new System.Drawing.Size(49, 20);
            this.labelTotalCarrinho.TabIndex = 14;
            this.labelTotalCarrinho.Text = "label";
            // 
            // labelOrcamentoMensal
            // 
            this.labelOrcamentoMensal.AutoSize = true;
            this.labelOrcamentoMensal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrcamentoMensal.Location = new System.Drawing.Point(227, 43);
            this.labelOrcamentoMensal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOrcamentoMensal.Name = "labelOrcamentoMensal";
            this.labelOrcamentoMensal.Size = new System.Drawing.Size(49, 20);
            this.labelOrcamentoMensal.TabIndex = 13;
            this.labelOrcamentoMensal.Text = "label";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Orçamento Disponível:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total no Carrinho:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Orçamento Mensal:";
            // 
            // labelEstadoAtual
            // 
            this.labelEstadoAtual.AutoSize = true;
            this.labelEstadoAtual.Location = new System.Drawing.Point(687, 9);
            this.labelEstadoAtual.Name = "labelEstadoAtual";
            this.labelEstadoAtual.Size = new System.Drawing.Size(44, 16);
            this.labelEstadoAtual.TabIndex = 1;
            this.labelEstadoAtual.Text = "label8";
            // 
            // FormModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 671);
            this.Controls.Add(this.labelEstadoAtual);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormModoCompra";
            this.Text = "Modo Compra";
            this.Load += new System.EventHandler(this.FormModoCompra_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQtd)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelAviso.ResumeLayout(false);
            this.panelAviso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownQtd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxArtigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxObservacoes;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelOrcamentoMensal;
        private System.Windows.Forms.Label labelOrcamentoDisponivel;
        private System.Windows.Forms.Label labelTotalCarrinho;
        private System.Windows.Forms.Panel panelAviso;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar progressBarItensPrevistos;
        private System.Windows.Forms.Button btnFinalizarCompra;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnLimparCarrinho;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label labellProgressoItens;
        private System.Windows.Forms.Label labelEstadoAtual;
    }
}