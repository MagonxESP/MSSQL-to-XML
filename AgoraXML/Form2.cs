using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgoraXML
{
    public partial class Form2 : Form
    {
        private DBtoXML dbxml;
        private List<string> tables;
        private SaveFileDialog explorer;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainForm.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.explorer = new SaveFileDialog();
            explorer.FileName = "export.xml";
            explorer.Filter = "XML (*.xml)|*.xml";
            this.dbxml = Program.dbxml;
            this.tables = new List<string>();
            this.initTables();
        }

        private void initTables()
        {
            this.tables = this.dbxml.getTables();

            if(tables.Count > 0)
            {
                for (int i = 0; i < tables.Count; i++)
                {
                    tablesDropDown.Items.Add(this.tables[i]);
                }
            }
            else
            {
                Alert.Warning("No se han encontrado las tablas de esta base de datos!");
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exportAllBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = explorer.ShowDialog();
            
            if(dr == DialogResult.OK)
            {
                Console.WriteLine(explorer.FileName);
            }
        }

        private void exportTablebtn_Click(object sender, EventArgs e)
        {

        }
    }
}
