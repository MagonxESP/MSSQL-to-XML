using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace mssqltoxml
{
    public partial class Form2 : Form
    {
        private DBtoXML dbxml;
        private List<string> tables;
        private SaveFileDialog explorer;
        private string table;
        private string database;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.dbxml.close();
            Program.mainForm.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.explorer = new SaveFileDialog();
            explorer.Filter = "XML (*.xml)|*.xml"; // extension del archivo por defecto
            this.dbxml = Program.dbxml;
            this.database = Program.dbName;
            this.tables = new List<string>();
            label1.Text += this.database;
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
            explorer.FileName = "export_" + this.database + ".xml"; // nombre por defecto del xml que exportamos
            DialogResult dr = explorer.ShowDialog();
            
            if(dr == DialogResult.OK)
            {
                string xml = dbxml.tablesToXml(this.database);
                if(DBtoXML.WriteXmlStringToFile(explorer.FileName, xml))
                {
                    Alert.Info("Se han exportado todas las tablas a " + explorer.FileName);
                    this.OpenFile(explorer.FileName);
                }
                else
                {
                    Alert.Warning("Fallo al exportar todas las tablas");
                }
            }
        }

        private void exportTablebtn_Click(object sender, EventArgs e)
        {
            if(this.table != null)
            {
                explorer.FileName = "export_" + this.table + ".xml";
                DialogResult dr = explorer.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    string xml = dbxml.tableToXml(this.table);

                    if(DBtoXML.WriteXmlStringToFile(explorer.FileName, xml))
                    {
                        Alert.Info("Se ha exportado " + this.table + " a " + explorer.FileName);
                        this.OpenFile(explorer.FileName);
                    }
                    else
                    {
                        Alert.Warning("Fallo al exportar " + this.table);
                    }
                }
            }
            else
            {
                Alert.Warning("Debes seleccionar una tabla!");
            }
        }

        private void tablesDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.table = (string) tablesDropDown.SelectedItem;
        }

        private void OpenFile(string path)
        {
            if(Alert.Confirm("¿Abrir?", "¿Deseas abrir el fichero exportado?"))
            {
                Process.Start(path);
            }
        }
    }
}
