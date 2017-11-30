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
            this.SuspendLayout();
            // 
            // tableExportList
            // 
            this.tableExportList.FormattingEnabled = true;
            this.tableExportList.Location = new System.Drawing.Point(12, 44);
            this.tableExportList.Name = "tableExportList";
            this.tableExportList.Size = new System.Drawing.Size(151, 154);
            this.tableExportList.TabIndex = 0;
            this.tableExportList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tableExportList_ItemCheck);
            // 
            // initExportLoopBtn
            // 
            this.initExportLoopBtn.Location = new System.Drawing.Point(210, 159);
            this.initExportLoopBtn.Name = "initExportLoopBtn";
            this.initExportLoopBtn.Size = new System.Drawing.Size(174, 39);
            this.initExportLoopBtn.TabIndex = 1;
            this.initExportLoopBtn.Text = "Seleccionar tablas y exportar";
            this.initExportLoopBtn.UseVisualStyleBackColor = true;
            this.initExportLoopBtn.Click += new System.EventHandler(this.initExportLoopBtn_Click);
            // 
            // Standalone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 210);
            this.Controls.Add(this.initExportLoopBtn);
            this.Controls.Add(this.tableExportList);
            this.Name = "Standalone";
            this.Text = "standalone";
            this.Load += new System.EventHandler(this.Standalone_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox tableExportList;
        private System.Windows.Forms.Button initExportLoopBtn;
    }
}