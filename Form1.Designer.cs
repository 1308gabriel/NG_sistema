
namespace NG_sistema
{
    partial class Form1_Autentication
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_usuario = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.radioButton_ver = new System.Windows.Forms.RadioButton();
            this.button_ingresar = new System.Windows.Forms.Button();
            this.label_nombreEmpresa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_usuario.Location = new System.Drawing.Point(177, 128);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(258, 26);
            this.textBox_usuario.TabIndex = 0;
            // 
            // textBox_password
            // 
            this.textBox_password.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_password.Location = new System.Drawing.Point(177, 181);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(258, 26);
            this.textBox_password.TabIndex = 1;
            // 
            // label_usuario
            // 
            this.label_usuario.AutoSize = true;
            this.label_usuario.Location = new System.Drawing.Point(87, 134);
            this.label_usuario.Name = "label_usuario";
            this.label_usuario.Size = new System.Drawing.Size(84, 20);
            this.label_usuario.TabIndex = 2;
            this.label_usuario.Text = "USUARIO";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(52, 187);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(119, 20);
            this.label_password.TabIndex = 3;
            this.label_password.Text = "CONTRASEÑA";
            // 
            // radioButton_ver
            // 
            this.radioButton_ver.AutoSize = true;
            this.radioButton_ver.Location = new System.Drawing.Point(442, 182);
            this.radioButton_ver.Name = "radioButton_ver";
            this.radioButton_ver.Size = new System.Drawing.Size(59, 24);
            this.radioButton_ver.TabIndex = 4;
            this.radioButton_ver.TabStop = true;
            this.radioButton_ver.Text = "Ver";
            this.radioButton_ver.UseVisualStyleBackColor = true;
            this.radioButton_ver.CheckedChanged += new System.EventHandler(this.radioButton_ver_CheckedChanged);
            // 
            // button_ingresar
            // 
            this.button_ingresar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button_ingresar.Location = new System.Drawing.Point(229, 256);
            this.button_ingresar.Name = "button_ingresar";
            this.button_ingresar.Size = new System.Drawing.Size(112, 33);
            this.button_ingresar.TabIndex = 5;
            this.button_ingresar.Text = "INGRESAR";
            this.button_ingresar.UseVisualStyleBackColor = false;
            this.button_ingresar.Click += new System.EventHandler(this.button_ingresar_Click);
            // 
            // label_nombreEmpresa
            // 
            this.label_nombreEmpresa.AutoSize = true;
            this.label_nombreEmpresa.Location = new System.Drawing.Point(191, 47);
            this.label_nombreEmpresa.Name = "label_nombreEmpresa";
            this.label_nombreEmpresa.Size = new System.Drawing.Size(51, 20);
            this.label_nombreEmpresa.TabIndex = 6;
            this.label_nombreEmpresa.Text = "label1";
            this.label_nombreEmpresa.Click += new System.EventHandler(this.label_nombreEmpresa_Click);
            // 
            // Form1_Autentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(550, 373);
            this.Controls.Add(this.label_nombreEmpresa);
            this.Controls.Add(this.button_ingresar);
            this.Controls.Add(this.radioButton_ver);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_usuario);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_usuario);
            this.Name = "Form1_Autentication";
            this.Text = "Autentication.";
            this.Load += new System.EventHandler(this.Form1_Autentication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_usuario;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.RadioButton radioButton_ver;
        private System.Windows.Forms.Button button_ingresar;
        private System.Windows.Forms.Label label_nombreEmpresa;
    }
}

