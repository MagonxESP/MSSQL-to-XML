namespace AgoraXML
{
    partial class Form2
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
            this.tablesDropDown = new System.Windows.Forms.ComboBox();
            this.exportAllBtn = new System.Windows.Forms.Button();
            this.exportTablebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.exitbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tablesDropDown
            // 
            this.tablesDropDown.FormattingEnabled = true;
            this.tablesDropDown.Location = new System.Drawing.Point(50, 45);
            this.tablesDropDown.Name = "tablesDropDown";
            this.tablesDropDown.Size = new System.Drawing.Size(336, 21);
            this.tablesDropDown.TabIndex = 0;
            // 
            // exportAllBtn
            // 
            this.exportAllBtn.Location = new System.Drawing.Point(12, 94);
            this.exportAllBtn.Name = "exportAllBtn";
            this.exportAllBtn.Size = new System.Drawing.Size(126, 33);
            this.exportAllBtn.TabIndex = 1;
            this.exportAllBtn.Text = "Exportar todo";
            this.exportAllBtn.UseVisualStyleBackColor = true;
            this.exportAllBtn.Click += new System.EventHandler(this.exportAllBtn_Click);
            // 
            // exportTablebtn
            // 
            this.exportTablebtn.Location = new System.Drawing.Point(155, 94);
            this.exportTablebtn.Name = "exportTablebtn";
            this.exportTablebtn.Size = new System.Drawing.Size(131, 33);
            this.exportTablebtn.TabIndex = 2;
            this.exportTablebtn.Text = "Exportar tabla";
            this.exportTablebtn.UseVisualStyleBackColor = true;
            this.exportTablebtn.Click += new System.EventHandler(this.exportTablebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tablas de la base de datos";
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(301, 94);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(127, 33);
            this.exitbtn.TabIndex = 4;
            this.exitbtn.Text = "Salir";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 154);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportTablebtn);
            this.Controls.Add(this.exportAllBtn);
            this.Controls.Add(this.tablesDropDown);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tablesDropDown;
        private System.Windows.Forms.Button exportAllBtn;
        private System.Windows.Forms.Button exportTablebtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitbtn;
    }
}