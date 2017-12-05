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
        private NotifyIcon notifyIcon;
        private ContextMenu notifyIconMenu;

        public Standalone()
        {
            InitializeComponent();
        }

        private void Standalone_Load(object sender, EventArgs e)
        {
            // inicializacion de componentes
            this.temporizador = new Timer();
            this.explorer = new FolderBrowserDialog();
            this.notifyIcon = new NotifyIcon();
            this.notifyIconMenu = new ContextMenu();

            // carga de componentes
            this.dbxml = Program.dbxml;
            this.db = Program.dbName;
            this.loadTables();
            this.notifyIcon.Icon = this.Icon;
            this.notifyIcon.ContextMenu = this.notifyIconMenu;
            this.loadNotifyIconMenu();

            // inicializacion de eventos
            this.temporizador.Tick += new EventHandler(this.temporizador_Tick);
            this.notifyIcon.DoubleClick += new EventHandler(this.maximizeFromSystemTray);
        }

        private void temporizador_Tick(object sender, EventArgs e)
        {
            this.exportar();
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

                statusText.ForeColor = Color.GreenYellow;
                statusText.Text = "Preparado";
            }
            else
            {
                statusText.ForeColor = Color.Red;
                statusText.Text = "Error";

                Alert.Warning("Esta base de datos no tiene tablas!");

                if(Alert.Confirm("Sin tablas el programa no funcionara correctamente\n¿Cerrar la aplicacion?"))
                {
                    Application.Exit();
                }
            }
        }

        private void loadNotifyIconMenu()
        {
            /**
             * Acabar el menu del icono
             */
            MenuItem[] menuItem = { new MenuItem() };

            menuItem[0].Index = 0;
            menuItem[0].Text = "Salir";
            menuItem[0].Click += new EventHandler(this.salir);

            menuItem[1].Index = 1;
            menuItem[1].Text = "Mostrar";
            menuItem[1].Click += new EventHandler(this.maximizeFromSystemTray);

            this.notifyIconMenu.MenuItems.AddRange(menuItem);
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
                int value = (int) intervalValue.Value;
                string interval = (string) intervalType.SelectedItem;

                this.SelectTables();

                if (value > 0 && interval != null && interval != "")
                {
                    this.temporizador.Interval = this.getMilliseconds(value, interval);
                    this.temporizador.Start();

                    statusText.ForeColor = Color.Yellow;
                    statusText.Text = "Trabajando...";

                    this.toSystemTray();
                }
                else
                {
                    string msg = "Las tablas se exportaran solo una vez porque no hay un intervalo establecido\n" +
                                 "¿Exportar igualmente?";

                    if (Alert.Confirm(msg))
                    {
                        this.exportar();

                        statusText.ForeColor = Color.Green;
                        statusText.Text = "Tablas exportadas!";
                    }
                }
            }
        }

        private int getMilliseconds(int value, string interval)
        {
            TimeSpan time = new TimeSpan();

            switch (interval)
            {
                case "Segundos":
                    time = TimeSpan.FromSeconds(value);
                    break;
                case "Minutos":
                    time = TimeSpan.FromMinutes(value);
                    break;
                case "Horas":
                    time = TimeSpan.FromHours(value);
                    break;
                case "Dias":
                    time = TimeSpan.FromDays(value);
                    break;
            }

            return (int) time.TotalMilliseconds;
        }

        private void toSystemTray()
        {
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipTitle = "MSSQL to XML";
            this.notifyIcon.BalloonTipText = "El programa sigue ejecutandose en segundo plano!";
            this.notifyIcon.ShowBalloonTip(100);
            this.Hide();
        }

        private void maximizeFromSystemTray(object sender, EventArgs e)
        {
            this.Show();
            this.notifyIcon.Visible = false;
        }

        private void Standalone_FormClosing(object sender, FormClosingEventArgs e)
        {
            // NOTA: Solucionar el cierre de la aplicacion!!

            bool continueInBackground = Alert.Confirm("¿Seguir ejecutando el programa en segundo plano?");

            if (continueInBackground)
            {
                e.Cancel = true; // Cancelamos el evento para que no elimine de la memoria el formulario
                this.toSystemTray();
            }
        }

        private void salir(object sender, EventArgs e)
        {
            if(Alert.Confirm("¿Parar el proceso y salir de la aplicacion?"))
            {
                this.temporizador.Stop();
                Application.Exit();
            }
        }
    }
}
