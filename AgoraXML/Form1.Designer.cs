namespace AgoraXML
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.hostsDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dbDropDown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.testConnectionBtn = new System.Windows.Forms.Button();
            this.conexionBtn = new System.Windows.Forms.Button();
            this.connectSilentModeBtn = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host";
            // 
            // hostsDropDown
            // 
            this.hostsDropDown.FormattingEnabled = true;
            this.hostsDropDown.Location = new System.Drawing.Point(12, 76);
            this.hostsDropDown.Name = "hostsDropDown";
            this.hostsDropDown.Size = new System.Drawing.Size(143, 21);
            this.hostsDropDown.TabIndex = 2;
            this.hostsDropDown.SelectedIndexChanged += new System.EventHandler(this.hostsDropDown_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Base de Datos";
            // 
            // dbDropDown
            // 
            this.dbDropDown.FormattingEnabled = true;
            this.dbDropDown.Location = new System.Drawing.Point(12, 120);
            this.dbDropDown.Name = "dbDropDown";
            this.dbDropDown.Size = new System.Drawing.Size(140, 21);
            this.dbDropDown.TabIndex = 4;
            this.dbDropDown.SelectedIndexChanged += new System.EventHandler(this.dbDropDown_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usuario";
            // 
            // userInput
            // 
            this.userInput.BackColor = System.Drawing.SystemColors.Window;
            this.userInput.Location = new System.Drawing.Point(12, 165);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(140, 20);
            this.userInput.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Contraseña";
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(12, 209);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(140, 20);
            this.passwordInput.TabIndex = 8;
            this.passwordInput.UseSystemPasswordChar = true;
            // 
            // testConnectionBtn
            // 
            this.testConnectionBtn.Location = new System.Drawing.Point(199, 91);
            this.testConnectionBtn.Name = "testConnectionBtn";
            this.testConnectionBtn.Size = new System.Drawing.Size(178, 39);
            this.testConnectionBtn.TabIndex = 9;
            this.testConnectionBtn.Text = "Probar conexión";
            this.testConnectionBtn.UseVisualStyleBackColor = true;
            this.testConnectionBtn.Click += new System.EventHandler(this.testConnectionBtn_Click);
            // 
            // conexionBtn
            // 
            this.conexionBtn.Location = new System.Drawing.Point(199, 155);
            this.conexionBtn.Name = "conexionBtn";
            this.conexionBtn.Size = new System.Drawing.Size(178, 39);
            this.conexionBtn.TabIndex = 10;
            this.conexionBtn.Text = "Conectar";
            this.conexionBtn.UseVisualStyleBackColor = true;
            this.conexionBtn.Click += new System.EventHandler(this.conexionBtn_Click);
            // 
            // connectSilentModeBtn
            // 
            this.connectSilentModeBtn.AutoSize = true;
            this.connectSilentModeBtn.Location = new System.Drawing.Point(244, 240);
            this.connectSilentModeBtn.Name = "connectSilentModeBtn";
            this.connectSilentModeBtn.Size = new System.Drawing.Size(170, 13);
            this.connectSilentModeBtn.TabIndex = 11;
            this.connectSilentModeBtn.TabStop = true;
            this.connectSilentModeBtn.Text = "Conectar y usar el modo silencioso";
            this.connectSilentModeBtn.Click += new System.EventHandler(this.connectSilentModeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 262);
            this.Controls.Add(this.connectSilentModeBtn);
            this.Controls.Add(this.conexionBtn);
            this.Controls.Add(this.testConnectionBtn);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dbDropDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hostsDropDown);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox hostsDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dbDropDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.Button testConnectionBtn;
        private System.Windows.Forms.Button conexionBtn;
        private System.Windows.Forms.LinkLabel connectSilentModeBtn;
    }
}

