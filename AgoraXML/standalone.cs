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
    public partial class Standalone : Form
    {
        private Timer temporizador;
        private DBtoXML dbxml;
        private string db;
        private List<string> tablesExport;
        private FolderBrowserDialog explorer;

        public Standalone()
        {
            InitializeComponent();
        }

        private void Standalone_Load(object sender, EventArgs e)
        {
            this.temporizador = new Timer();
            this.explorer = new FolderBrowserDialog();
            this.dbxml = Program.dbxml;
            this.db = Program.dbName;
            this.loadTables();
           // this.temporizador.Tick += new EventHandler(this.exportar);
        }

        private void loadTables()
        {
            List<string> tables = new List<string>();

            tables = this.dbxml.getTables();

            if(tables.Count > 0)
            {
                for(int i = 0; i < tables.Count; i++)
                {
                    tableExportList.Items.Add(tables[i]);
                }
            }
            else
            {
                Alert.Warning("Esta base de datos no tiene tablas!");

                if(Alert.Confirm("Sin tablas el programa no funcionara correctamente\n¿Cerrar la aplicacion?"))
                {
                    Application.Exit();
                }
            }
        }

        private void exportar()
        {
            for(int i = 0; i < this.tablesExport.Count; i++)
            {
                string path = explorer.SelectedPath + "\\" + this.tablesExport[i] + ".xml";
                string xmlString = this.dbxml.tableToXml(this.tablesExport[i]);

                if(xmlString != null && xmlString != "")
                {
                    DBtoXML.WriteXmlStringToFile(path, xmlString);
                }
            }
        }

        private void tableExportList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void SelectTables()
        {
            this.tablesExport = new List<string>();

            for (int i = 0; i < tableExportList.CheckedItems.Count; i++)
            {
                if (tableExportList.CheckedItems[i] != null)
                {
                    this.tablesExport.Add((string) tableExportList.CheckedItems[i]);
                }
            }
        }

        private void initExportLoopBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = explorer.ShowDialog();

            if(dr == DialogResult.OK)
            {
                this.SelectTables();
                this.exportar(); // se llama aqui para probarlo
                //temporizador.Start();
            }
        }
    }
}
