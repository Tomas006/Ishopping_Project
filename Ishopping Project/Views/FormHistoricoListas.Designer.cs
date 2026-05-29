namespace Ishopping_Project.Views
{
    partial class FormHistoricoListas
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
            this.radioButtonFechadas = new System.Windows.Forms.RadioButton();
            this.radioButtonEmCompra = new System.Windows.Forms.RadioButton();
            this.radioButtonPlaneadas = new System.Windows.Forms.RadioButton();
            this.radioButtonTodas = new System.Windows.Forms.RadioButton();
            this.dataGridViewListas = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonFechadas);
            this.groupBox1.Controls.Add(this.radioButtonEmCompra);
            this.groupBox1.Controls.Add(this.radioButtonPlaneadas);
            this.groupBox1.Controls.Add(this.radioButtonTodas);
            this.groupBox1.Location = new System.Drawing.Point(17, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por Estado";
            // 
            // radioButtonFechadas
            // 
            this.radioButtonFechadas.AutoSize = true;
            this.radioButtonFechadas.Location = new System.Drawing.Point(465, 32);
            this.radioButtonFechadas.Name = "radioButtonFechadas";
            this.radioButtonFechadas.Size = new System.Drawing.Size(89, 20);
            this.radioButtonFechadas.TabIndex = 4;
            this.radioButtonFechadas.TabStop = true;
            this.radioButtonFechadas.Text = "Fechadas";
            this.radioButtonFechadas.UseVisualStyleBackColor = true;
            // 
            // radioButtonEmCompra
            // 
            this.radioButtonEmCompra.AutoSize = true;
            this.radioButtonEmCompra.Location = new System.Drawing.Point(314, 32);
            this.radioButtonEmCompra.Name = "radioButtonEmCompra";
            this.radioButtonEmCompra.Size = new System.Drawing.Size(99, 20);
            this.radioButtonEmCompra.TabIndex = 3;
            this.radioButtonEmCompra.TabStop = true;
            this.radioButtonEmCompra.Text = "Em Compra";
            this.radioButtonEmCompra.UseVisualStyleBackColor = true;
            // 
            // radioButtonPlaneadas
            // 
            this.radioButtonPlaneadas.AutoSize = true;
            this.radioButtonPlaneadas.Location = new System.Drawing.Point(159, 32);
            this.radioButtonPlaneadas.Name = "radioButtonPlaneadas";
            this.radioButtonPlaneadas.Size = new System.Drawing.Size(94, 20);
            this.radioButtonPlaneadas.TabIndex = 2;
            this.radioButtonPlaneadas.TabStop = true;
            this.radioButtonPlaneadas.Text = "Planeadas";
            this.radioButtonPlaneadas.UseVisualStyleBackColor = true;
            // 
            // radioButtonTodas
            // 
            this.radioButtonTodas.AutoSize = true;
            this.radioButtonTodas.Location = new System.Drawing.Point(28, 32);
            this.radioButtonTodas.Name = "radioButtonTodas";
            this.radioButtonTodas.Size = new System.Drawing.Size(68, 20);
            this.radioButtonTodas.TabIndex = 1;
            this.radioButtonTodas.TabStop = true;
            this.radioButtonTodas.Text = "Todas";
            this.radioButtonTodas.UseVisualStyleBackColor = true;
            // 
            // dataGridViewListas
            // 
            this.dataGridViewListas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListas.Location = new System.Drawing.Point(18, 125);
            this.dataGridViewListas.Name = "dataGridViewListas";
            this.dataGridViewListas.RowHeadersWidth = 51;
            this.dataGridViewListas.RowTemplate.Height = 24;
            this.dataGridViewListas.Size = new System.Drawing.Size(764, 228);
            this.dataGridViewListas.TabIndex = 1;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(18, 381);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(141, 45);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(641, 381);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(141, 45);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // FormHistoricoListas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dataGridViewListas);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormHistoricoListas";
            this.Text = "FormHistoricoListas";
            this.Load += new System.EventHandler(this.FormHistoricoListas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonFechadas;
        private System.Windows.Forms.RadioButton radioButtonEmCompra;
        private System.Windows.Forms.RadioButton radioButtonPlaneadas;
        private System.Windows.Forms.RadioButton radioButtonTodas;
        private System.Windows.Forms.DataGridView dataGridViewListas;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnEditar;
    }
}