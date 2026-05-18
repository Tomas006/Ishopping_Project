namespace Ishopping_Project
{
    partial class Form1
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
            this.Login = new System.Windows.Forms.TabControl();
            this.Registar = new System.Windows.Forms.TabPage();
            this.btnConfirmarRegistar = new System.Windows.Forms.Button();
            this.btnCancelarRegistar = new System.Windows.Forms.Button();
            this.textPasswordRegistar = new System.Windows.Forms.TextBox();
            this.textUsernameRegistar = new System.Windows.Forms.TextBox();
            this.textÑome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Entrar = new System.Windows.Forms.TabPage();
            this.btnConfirmarEntrar = new System.Windows.Forms.Button();
            this.btnCancelarEntrar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textPasswordEntrar = new System.Windows.Forms.TextBox();
            this.textUsernameEntrar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Login.SuspendLayout();
            this.Registar.SuspendLayout();
            this.Entrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Controls.Add(this.Registar);
            this.Login.Controls.Add(this.Entrar);
            this.Login.Location = new System.Drawing.Point(23, 31);
            this.Login.Name = "Login";
            this.Login.SelectedIndex = 0;
            this.Login.Size = new System.Drawing.Size(330, 407);
            this.Login.TabIndex = 0;
            // 
            // Registar
            // 
            this.Registar.Controls.Add(this.btnConfirmarRegistar);
            this.Registar.Controls.Add(this.btnCancelarRegistar);
            this.Registar.Controls.Add(this.textPasswordRegistar);
            this.Registar.Controls.Add(this.textUsernameRegistar);
            this.Registar.Controls.Add(this.textÑome);
            this.Registar.Controls.Add(this.label4);
            this.Registar.Controls.Add(this.label3);
            this.Registar.Controls.Add(this.label2);
            this.Registar.Controls.Add(this.label1);
            this.Registar.Location = new System.Drawing.Point(4, 25);
            this.Registar.Name = "Registar";
            this.Registar.Padding = new System.Windows.Forms.Padding(3);
            this.Registar.Size = new System.Drawing.Size(322, 378);
            this.Registar.TabIndex = 0;
            this.Registar.Text = "tabPage1";
            this.Registar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmarRegistar
            // 
            this.btnConfirmarRegistar.Location = new System.Drawing.Point(179, 306);
            this.btnConfirmarRegistar.Name = "btnConfirmarRegistar";
            this.btnConfirmarRegistar.Size = new System.Drawing.Size(101, 43);
            this.btnConfirmarRegistar.TabIndex = 15;
            this.btnConfirmarRegistar.Text = "Confirmar";
            this.btnConfirmarRegistar.UseVisualStyleBackColor = true;
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
            // textPasswordRegistar
            // 
            this.textPasswordRegistar.Location = new System.Drawing.Point(97, 242);
            this.textPasswordRegistar.Name = "textPasswordRegistar";
            this.textPasswordRegistar.Size = new System.Drawing.Size(165, 22);
            this.textPasswordRegistar.TabIndex = 6;
            // 
            // textUsernameRegistar
            // 
            this.textUsernameRegistar.Location = new System.Drawing.Point(97, 175);
            this.textUsernameRegistar.Name = "textUsernameRegistar";
            this.textUsernameRegistar.Size = new System.Drawing.Size(165, 22);
            this.textUsernameRegistar.TabIndex = 5;
            // 
            // textÑome
            // 
            this.textÑome.Location = new System.Drawing.Point(97, 108);
            this.textÑome.Name = "textÑome";
            this.textÑome.Size = new System.Drawing.Size(165, 22);
            this.textÑome.TabIndex = 4;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // Entrar
            // 
            this.Entrar.Controls.Add(this.btnConfirmarEntrar);
            this.Entrar.Controls.Add(this.btnCancelarEntrar);
            this.Entrar.Controls.Add(this.label7);
            this.Entrar.Controls.Add(this.textPasswordEntrar);
            this.Entrar.Controls.Add(this.textUsernameEntrar);
            this.Entrar.Controls.Add(this.label5);
            this.Entrar.Controls.Add(this.label6);
            this.Entrar.Location = new System.Drawing.Point(4, 25);
            this.Entrar.Name = "Entrar";
            this.Entrar.Padding = new System.Windows.Forms.Padding(3);
            this.Entrar.Size = new System.Drawing.Size(322, 378);
            this.Entrar.TabIndex = 1;
            this.Entrar.Text = "tabPage2";
            this.Entrar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmarEntrar
            // 
            this.btnConfirmarEntrar.Location = new System.Drawing.Point(169, 299);
            this.btnConfirmarEntrar.Name = "btnConfirmarEntrar";
            this.btnConfirmarEntrar.Size = new System.Drawing.Size(101, 43);
            this.btnConfirmarEntrar.TabIndex = 13;
            this.btnConfirmarEntrar.Text = "Confirmar";
            this.btnConfirmarEntrar.UseVisualStyleBackColor = true;
            this.btnConfirmarEntrar.Click += new System.EventHandler(this.btnConfirmarEntrar_Click);
            // 
            // btnCancelarEntrar
            // 
            this.btnCancelarEntrar.Location = new System.Drawing.Point(41, 299);
            this.btnCancelarEntrar.Name = "btnCancelarEntrar";
            this.btnCancelarEntrar.Size = new System.Drawing.Size(101, 43);
            this.btnCancelarEntrar.TabIndex = 12;
            this.btnCancelarEntrar.Text = "Cancelar";
            this.btnCancelarEntrar.UseVisualStyleBackColor = true;
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
            // textPasswordEntrar
            // 
            this.textPasswordEntrar.Location = new System.Drawing.Point(105, 231);
            this.textPasswordEntrar.Name = "textPasswordEntrar";
            this.textPasswordEntrar.Size = new System.Drawing.Size(165, 22);
            this.textPasswordEntrar.TabIndex = 10;
            // 
            // textUsernameEntrar
            // 
            this.textUsernameEntrar.Location = new System.Drawing.Point(105, 164);
            this.textUsernameEntrar.Name = "textUsernameEntrar";
            this.textUsernameEntrar.Size = new System.Drawing.Size(165, 22);
            this.textUsernameEntrar.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Username:";
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 450);
            this.Controls.Add(this.Login);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Login.ResumeLayout(false);
            this.Registar.ResumeLayout(false);
            this.Registar.PerformLayout();
            this.Entrar.ResumeLayout(false);
            this.Entrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Login;
        private System.Windows.Forms.TabPage Registar;
        private System.Windows.Forms.TabPage Entrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPasswordRegistar;
        private System.Windows.Forms.TextBox textUsernameRegistar;
        private System.Windows.Forms.TextBox textÑome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textPasswordEntrar;
        private System.Windows.Forms.TextBox textUsernameEntrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConfirmarEntrar;
        private System.Windows.Forms.Button btnCancelarEntrar;
        private System.Windows.Forms.Button btnConfirmarRegistar;
        private System.Windows.Forms.Button btnCancelarRegistar;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

