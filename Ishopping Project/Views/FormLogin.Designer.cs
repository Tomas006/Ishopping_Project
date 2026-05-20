namespace Ishopping_Project
{
    partial class FormLogin
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
            this.components = new System.ComponentModel.Container();
            this.tabController = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textUsernameEntrar = new System.Windows.Forms.TextBox();
            this.textPasswordEntrar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelarEntrar = new System.Windows.Forms.Button();
            this.btnConfirmarEntrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textNome = new System.Windows.Forms.TextBox();
            this.textUsernameRegistar = new System.Windows.Forms.TextBox();
            this.textPasswordRegistar = new System.Windows.Forms.TextBox();
            this.btnCancelarRegistar = new System.Windows.Forms.Button();
            this.btnConfirmarRegistar = new System.Windows.Forms.Button();
            this.tabController.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Controls.Add(this.tabPage1);
            this.tabController.Controls.Add(this.tabPage2);
            this.tabController.Location = new System.Drawing.Point(12, 12);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(330, 407);
            this.tabController.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnConfirmarRegistar);
            this.tabPage1.Controls.Add(this.btnCancelarRegistar);
            this.tabPage1.Controls.Add(this.textPasswordRegistar);
            this.tabPage1.Controls.Add(this.textUsernameRegistar);
            this.tabPage1.Controls.Add(this.textNome);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(322, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Registar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnConfirmarEntrar);
            this.tabPage2.Controls.Add(this.btnCancelarEntrar);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textPasswordEntrar);
            this.tabPage2.Controls.Add(this.textUsernameEntrar);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(322, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Entrar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password:";
            // 
            // textUsernameEntrar
            // 
            this.textUsernameEntrar.Location = new System.Drawing.Point(109, 133);
            this.textUsernameEntrar.Name = "textUsernameEntrar";
            this.textUsernameEntrar.Size = new System.Drawing.Size(165, 22);
            this.textUsernameEntrar.TabIndex = 9;
            // 
            // textPasswordEntrar
            // 
            this.textPasswordEntrar.Location = new System.Drawing.Point(109, 200);
            this.textPasswordEntrar.Name = "textPasswordEntrar";
            this.textPasswordEntrar.Size = new System.Drawing.Size(165, 22);
            this.textPasswordEntrar.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(121, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 29);
            this.label7.TabIndex = 11;
            this.label7.Text = "Entrar";
            // 
            // btnCancelarEntrar
            // 
            this.btnCancelarEntrar.Location = new System.Drawing.Point(45, 268);
            this.btnCancelarEntrar.Name = "btnCancelarEntrar";
            this.btnCancelarEntrar.Size = new System.Drawing.Size(101, 43);
            this.btnCancelarEntrar.TabIndex = 12;
            this.btnCancelarEntrar.Text = "Cancelar";
            this.btnCancelarEntrar.UseVisualStyleBackColor = true;
            this.btnCancelarEntrar.Click += new System.EventHandler(this.btnCancelarEntrar_Click);
            // 
            // btnConfirmarEntrar
            // 
            this.btnConfirmarEntrar.Location = new System.Drawing.Point(173, 268);
            this.btnConfirmarEntrar.Name = "btnConfirmarEntrar";
            this.btnConfirmarEntrar.Size = new System.Drawing.Size(101, 43);
            this.btnConfirmarEntrar.TabIndex = 13;
            this.btnConfirmarEntrar.Text = "Confirmar";
            this.btnConfirmarEntrar.UseVisualStyleBackColor = true;
            this.btnConfirmarEntrar.Click += new System.EventHandler(this.btnConfirmarEntrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(109, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Registar";
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(97, 108);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(165, 22);
            this.textNome.TabIndex = 4;
            // 
            // textUsernameRegistar
            // 
            this.textUsernameRegistar.Location = new System.Drawing.Point(97, 175);
            this.textUsernameRegistar.Name = "textUsernameRegistar";
            this.textUsernameRegistar.Size = new System.Drawing.Size(165, 22);
            this.textUsernameRegistar.TabIndex = 5;
            // 
            // textPasswordRegistar
            // 
            this.textPasswordRegistar.Location = new System.Drawing.Point(97, 242);
            this.textPasswordRegistar.Name = "textPasswordRegistar";
            this.textPasswordRegistar.Size = new System.Drawing.Size(165, 22);
            this.textPasswordRegistar.TabIndex = 6;
            // 
            // btnCancelarRegistar
            // 
            this.btnCancelarRegistar.Location = new System.Drawing.Point(51, 306);
            this.btnCancelarRegistar.Name = "btnCancelarRegistar";
            this.btnCancelarRegistar.Size = new System.Drawing.Size(101, 43);
            this.btnCancelarRegistar.TabIndex = 14;
            this.btnCancelarRegistar.Text = "Cancelar";
            this.btnCancelarRegistar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmarRegistar
            // 
            this.btnConfirmarRegistar.Location = new System.Drawing.Point(179, 306);
            this.btnConfirmarRegistar.Name = "btnConfirmarRegistar";
            this.btnConfirmarRegistar.Size = new System.Drawing.Size(101, 43);
            this.btnConfirmarRegistar.TabIndex = 15;
            this.btnConfirmarRegistar.Text = "Confirmar";
            this.btnConfirmarRegistar.UseVisualStyleBackColor = true;
            this.btnConfirmarRegistar.Click += new System.EventHandler(this.btnConfirmarRegistar_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 436);
            this.Controls.Add(this.tabController);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabController.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabController;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnConfirmarRegistar;
        private System.Windows.Forms.Button btnCancelarRegistar;
        private System.Windows.Forms.TextBox textPasswordRegistar;
        private System.Windows.Forms.TextBox textUsernameRegistar;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirmarEntrar;
        private System.Windows.Forms.Button btnCancelarEntrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textPasswordEntrar;
        private System.Windows.Forms.TextBox textUsernameEntrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

