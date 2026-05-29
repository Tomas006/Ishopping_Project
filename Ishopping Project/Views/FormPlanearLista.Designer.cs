namespace Ishopping_Project.Views
{
    partial class FormPlanearLista
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
            this.txtNomeLista = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonListaExistente = new System.Windows.Forms.Button();
            this.labelOrcamentoMesAtual = new System.Windows.Forms.Label();
            this.labelTotalPlaneado = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDataCriacao = new System.Windows.Forms.TextBox();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdicionarArtigo = new System.Windows.Forms.Button();
            this.numericUpDownQuantidadePlaneada = new System.Windows.Forms.NumericUpDown();
            this.comboBoxArtigos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewLinhas = new System.Windows.Forms.DataGridView();
            this.btnRemoverArtigo = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidadePlaneada)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLinhas)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNomeLista);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonListaExistente);
            this.groupBox1.Controls.Add(this.labelOrcamentoMesAtual);
            this.groupBox1.Controls.Add(this.labelTotalPlaneado);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxDataCriacao);
            this.groupBox1.Controls.Add(this.comboBoxEstado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1046, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info da Lista Ativa";
            // 
            // txtNomeLista
            // 
            this.txtNomeLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeLista.Location = new System.Drawing.Point(154, 112);
            this.txtNomeLista.Name = "txtNomeLista";
            this.txtNomeLista.Size = new System.Drawing.Size(150, 27);
            this.txtNomeLista.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Nome da Lista:";
            // 
            // buttonListaExistente
            // 
            this.buttonListaExistente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListaExistente.Location = new System.Drawing.Point(384, 31);
            this.buttonListaExistente.Name = "buttonListaExistente";
            this.buttonListaExistente.Size = new System.Drawing.Size(208, 41);
            this.buttonListaExistente.TabIndex = 13;
            this.buttonListaExistente.Text = "Escolher Lista Já Criada";
            this.buttonListaExistente.UseVisualStyleBackColor = true;
            this.buttonListaExistente.Click += new System.EventHandler(this.buttonListaExistente_Click);
            // 
            // labelOrcamentoMesAtual
            // 
            this.labelOrcamentoMesAtual.AutoSize = true;
            this.labelOrcamentoMesAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrcamentoMesAtual.Location = new System.Drawing.Point(962, 31);
            this.labelOrcamentoMesAtual.Name = "labelOrcamentoMesAtual";
            this.labelOrcamentoMesAtual.Size = new System.Drawing.Size(49, 20);
            this.labelOrcamentoMesAtual.TabIndex = 6;
            this.labelOrcamentoMesAtual.Text = "label";
            // 
            // labelTotalPlaneado
            // 
            this.labelTotalPlaneado.AutoSize = true;
            this.labelTotalPlaneado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPlaneado.Location = new System.Drawing.Point(962, 71);
            this.labelTotalPlaneado.Name = "labelTotalPlaneado";
            this.labelTotalPlaneado.Size = new System.Drawing.Size(49, 20);
            this.labelTotalPlaneado.TabIndex = 11;
            this.labelTotalPlaneado.Text = "label";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(665, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Total Planeado Nesta Lista:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(685, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Orçamento do Mês Atual:";
            // 
            // textBoxDataCriacao
            // 
            this.textBoxDataCriacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDataCriacao.Location = new System.Drawing.Point(154, 31);
            this.textBoxDataCriacao.Name = "textBoxDataCriacao";
            this.textBoxDataCriacao.ReadOnly = true;
            this.textBoxDataCriacao.Size = new System.Drawing.Size(150, 27);
            this.textBoxDataCriacao.TabIndex = 3;
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Location = new System.Drawing.Point(154, 68);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(150, 28);
            this.comboBoxEstado.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data de Criação:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdicionarArtigo);
            this.groupBox2.Controls.Add(this.numericUpDownQuantidadePlaneada);
            this.groupBox2.Controls.Add(this.comboBoxArtigos);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(26, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 238);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adicionar Artigo à Lista";
            // 
            // btnAdicionarArtigo
            // 
            this.btnAdicionarArtigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarArtigo.Location = new System.Drawing.Point(16, 167);
            this.btnAdicionarArtigo.Name = "btnAdicionarArtigo";
            this.btnAdicionarArtigo.Size = new System.Drawing.Size(354, 41);
            this.btnAdicionarArtigo.TabIndex = 9;
            this.btnAdicionarArtigo.Text = "Adicionar Artigo";
            this.btnAdicionarArtigo.UseVisualStyleBackColor = true;
            this.btnAdicionarArtigo.Click += new System.EventHandler(this.btnAdicionarArtigo_Click);
            // 
            // numericUpDownQuantidadePlaneada
            // 
            this.numericUpDownQuantidadePlaneada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownQuantidadePlaneada.Location = new System.Drawing.Point(201, 104);
            this.numericUpDownQuantidadePlaneada.Name = "numericUpDownQuantidadePlaneada";
            this.numericUpDownQuantidadePlaneada.Size = new System.Drawing.Size(156, 27);
            this.numericUpDownQuantidadePlaneada.TabIndex = 7;
            // 
            // comboBoxArtigos
            // 
            this.comboBoxArtigos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxArtigos.FormattingEnabled = true;
            this.comboBoxArtigos.Location = new System.Drawing.Point(86, 38);
            this.comboBoxArtigos.Name = "comboBoxArtigos";
            this.comboBoxArtigos.Size = new System.Drawing.Size(271, 28);
            this.comboBoxArtigos.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Quantidade Planeada:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Artigo:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewLinhas);
            this.groupBox3.Controls.Add(this.btnRemoverArtigo);
            this.groupBox3.Location = new System.Drawing.Point(445, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(627, 294);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Artigos Planeados";
            // 
            // dataGridViewLinhas
            // 
            this.dataGridViewLinhas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLinhas.Location = new System.Drawing.Point(18, 21);
            this.dataGridViewLinhas.Name = "dataGridViewLinhas";
            this.dataGridViewLinhas.ReadOnly = true;
            this.dataGridViewLinhas.RowHeadersWidth = 51;
            this.dataGridViewLinhas.RowTemplate.Height = 24;
            this.dataGridViewLinhas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLinhas.Size = new System.Drawing.Size(589, 200);
            this.dataGridViewLinhas.TabIndex = 10;
            // 
            // btnRemoverArtigo
            // 
            this.btnRemoverArtigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverArtigo.Location = new System.Drawing.Point(142, 236);
            this.btnRemoverArtigo.Name = "btnRemoverArtigo";
            this.btnRemoverArtigo.Size = new System.Drawing.Size(367, 41);
            this.btnRemoverArtigo.TabIndex = 9;
            this.btnRemoverArtigo.Text = "Remover Artigo";
            this.btnRemoverArtigo.UseVisualStyleBackColor = true;
            this.btnRemoverArtigo.Click += new System.EventHandler(this.btnRemoverArtigo_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnVoltar);
            this.groupBox4.Controls.Add(this.btnLimpar);
            this.groupBox4.Controls.Add(this.btnGuardar);
            this.groupBox4.Location = new System.Drawing.Point(26, 512);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1046, 97);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ações";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(807, 33);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(208, 41);
            this.btnVoltar.TabIndex = 12;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(399, 33);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(367, 41);
            this.btnLimpar.TabIndex = 11;
            this.btnLimpar.Text = "Limpar Lista";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(16, 33);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(367, 41);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar Lista";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FormPlanearLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 638);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPlanearLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPlanearLista";
            
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidadePlaneada)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLinhas)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDataCriacao;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxArtigos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantidadePlaneada;
        private System.Windows.Forms.Button btnAdicionarArtigo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewLinhas;
        private System.Windows.Forms.Button btnRemoverArtigo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTotalPlaneado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelOrcamentoMesAtual;
        private System.Windows.Forms.Button buttonListaExistente;
        private System.Windows.Forms.TextBox txtNomeLista;
        private System.Windows.Forms.Label label5;
    }
}