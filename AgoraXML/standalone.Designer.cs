namespace AgoraXML
{
    partial class Standalone
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
            this.tableExportList = new System.Windows.Forms.CheckedListBox();
            this.initExportLoopBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.intervalType = new System.Windows.Forms.ComboBox();
            this.intervalValue = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusText = new System.Windows.Forms.Label();
            this.SaveConfBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.intervalValue)).BeginInit();
            this.SuspendLayout();
            // 
            // tableExportList
            // 
            this.tableExportList.FormattingEnabled = true;
            this.tableExportList.Location = new System.Drawing.Point(12, 44);
            this.tableExportList.Name = "tableExportList";
            this.tableExportList.Size = new System.Drawing.Size(151, 184);
            this.tableExportList.TabIndex = 0;
            this.tableExportList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tableExportList_ItemCheck);
            // 
            // initExportLoopBtn
            // 
            this.initExportLoopBtn.Location = new System.Drawing.Point(208, 125);
            this.initExportLoopBtn.Name = "initExportLoopBtn";
            this.initExportLoopBtn.Size = new System.Drawing.Size(174, 39);
            this.initExportLoopBtn.TabIndex = 1;
            this.initExportLoopBtn.Text = "Seleccionar tablas y exportar";
            this.initExportLoopBtn.UseVisualStyleBackColor = true;
            this.initExportLoopBtn.Click += new System.EventHandler(this.initExportLoopBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selecciona las tablas que quieres exportar";
            // 
            // intervalType
            // 
            this.intervalType.FormattingEnabled = true;
            this.intervalType.Items.AddRange(new object[] {
            "Segundos",
            "Minutos",
            "Horas",
            "Dias",
            "Meses",
            "Años"});
            this.intervalType.Location = new System.Drawing.Point(208, 98);
            this.intervalType.Name = "intervalType";
            this.intervalType.Size = new System.Drawing.Size(174, 21);
            this.intervalType.TabIndex = 3;
            // 
            // intervalValue
            // 
            this.intervalValue.Location = new System.Drawing.Point(208, 72);
            this.intervalValue.Name = "intervalValue";
            this.intervalValue.Size = new System.Drawing.Size(174, 20);
            this.intervalValue.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Exportar cada...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Estado:";
            // 
            // statusText
            // 
            this.statusText.AutoSize = true;
            this.statusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statusText.Location = new System.Drawing.Point(257, 213);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(41, 13);
            this.statusText.TabIndex = 7;
            this.statusText.Text = "label4";
            // 
            // SaveConfBtn
            // 
            this.SaveConfBtn.Location = new System.Drawing.Point(208, 170);
            this.SaveConfBtn.Name = "SaveConfBtn";
            this.SaveConfBtn.Size = new System.Drawing.Size(174, 34);
            this.SaveConfBtn.TabIndex = 8;
            this.SaveConfBtn.Text = "Guardar configuración";
            this.SaveConfBtn.UseVisualStyleBackColor = true;
            this.SaveConfBtn.Click += new System.EventHandler(this.SaveConfBtn_Click);
            // 
            // Standalone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 240);
            this.Controls.Add(this.SaveConfBtn);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.intervalValue);
            this.Controls.Add(this.intervalType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.initExportLoopBtn);
            this.Controls.Add(this.tableExportList);
            this.Name = "Standalone";
            this.Text = "standalone";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Standalone_FormClosing);
            this.Load += new System.EventHandler(this.Standalone_Load);
            ((System.ComponentModel.ISupportInitialize)(this.intervalValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox tableExportList;
        private System.Windows.Forms.Button initExportLoopBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox intervalType;
        private System.Windows.Forms.NumericUpDown intervalValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.Button SaveConfBtn;
    }
}