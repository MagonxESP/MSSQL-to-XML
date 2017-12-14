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
        private List<string> tableList;
        private FolderBrowserDialog explorer;
        private NotifyIcon notifyIcon;
        private ContextMenu notifyIconMenu;
        private Config conf;
        private bool noClose;
        private string SelectedPath;
        private bool isConfigured;

        public Standalone()
        {
            InitializeComponent();

            // inicializacion de componentes
            this.temporizador = new Timer();
            this.explorer = new FolderBrowserDialog();
            this.notifyIcon = new NotifyIcon();
            this.notifyIconMenu = new ContextMenu();
            this.isConfigured = false;
        }

        private void Standalone_Load(object sender, EventArgs e)
        {
            // carga de componentes

            if(!this.isConfigured)
            {
                // si no se ha configurado previamente
                // cargamos las variables
                this.dbxml = Program.dbxml;
                this.db = Program.dbName;
                this.conf = Program.conf;
            }

            this.loadTables();
            this.notifyIcon.Icon = this.Icon;
            this.notifyIcon.ContextMenu = this.notifyIconMenu;
            this.loadNotifyIconMenu();
            this.noClose = true;

            if (!this.hasConfigFile())
            {
                // si no existe fichero de configuracion
                this.DeleteConfigBtn.Enabled = false; // desactivamos este boton
            }

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
            this.tableList = new List<string>();

            this.tableList = this.dbxml.getTables();

            if(this.tableList.Count > 0)
            {
                for(int i = 0; i < this.tableList.Count; i++)
                {
                    tableExportList.Items.Add(this.tableList[i]);
                }

                statusText.ForeColor = Color.GreenYellow;
                statusText.Text = "Preparado";
            }
            else
            {
                statusText.ForeColor = Color.Red;
                statusText.Text = "Error";

                Alert.Warning("Esta base de datos no tiene tablas!");

                if(Alert.Confirm("¿Salir?", "Sin tablas el programa no funcionara correctamente\n¿Cerrar la aplicacion?"))
                {
                    Application.Exit();
                }
            }
        }

        private void loadNotifyIconMenu()
        {
            MenuItem[] menuItem = new MenuItem[2];

            // instanciamos cada posicion del vector
            for(int i = 0; i < menuItem.Length; i++)
            {
                menuItem[i] = new MenuItem();
            }

            // definimos cada item del menu
            menuItem[0].Index = 0;
            menuItem[0].Text = "Mostrar";
            menuItem[0].Click += new EventHandler(this.maximizeFromSystemTray);

            menuItem[1].Index = 0;
            menuItem[1].Text = "Salir";
            menuItem[1].Click += new EventHandler(this.Salir_Click);

            this.notifyIconMenu.MenuItems.AddRange(menuItem);
        }

        private void exportar()
        {
            for(int i = 0; i < this.tablesExport.Count; i++)
            {
                string path = this.SelectedPath + "\\" + this.tablesExport[i] + ".xml";
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

                this.SelectedPath = explorer.SelectedPath;

                this.SelectTables();

                if (value > 0 && interval != null && interval != "")
                {
                    this.temporizador.Interval = this.getMilliseconds(value, interval);
                    this.temporizador.Start();

                    statusText.ForeColor = Color.Yellow;
                    statusText.Text = "Trabajando...";

                    this.toSystemTray();

                    string title = "¿Guardar configuración?";
                    string msg = "¿Quieres guardar esta configuración para usarla mas tarde?";

                    if(Alert.Confirm(title, msg))
                    {
                        this.saveConfig();

                        if (!this.DeleteConfigBtn.Enabled)
                        {
                            // si el boton de eliminar la configuracion estaba desactivado
                            this.DeleteConfigBtn.Enabled = true; // lo activamos
                        }
                    }
                }
                else
                {
                    string title = "Exportar tablas";
                    string msg = "Las tablas se exportaran solo una vez porque no hay un intervalo establecido\n" +
                                 "¿Exportar igualmente?";

                    if (Alert.Confirm(title, msg))
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
            if (noClose)
            {
                e.Cancel = true; // Cancelamos el evento para que no elimine de la memoria el formulario
                this.toSystemTray();
            }
            else
            {
                e.Cancel = false; // No cancelamos el evento
            }
        }

        private void StopAndExit()
        {
            this.noClose = false;
            this.temporizador.Stop(); // para el temporizador
            this.Close(); // cierra este formulario
            Application.Exit(); // matamos el proceso
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            if (Alert.Confirm("¿Salir?", "¿Parar el proceso y salir de la aplicacion?"))
            {
                this.StopAndExit();
            }
        }

        private void saveConfig()
        {
            this.conf.setIntervalMs(this.temporizador.Interval);
            this.conf.setPath(this.SelectedPath);
            this.conf.setTablesToExport(this.tablesExport);

            if (this.conf.Save())
            {
                Alert.Info("La configuración se ha guardado con exito");
            }
            else
            {
                Alert.Warning("Error al guardar la configuración :(");
            }
        }

        public bool Configure(Config conf)
        {
            // restauramos la configuracion
            this.conf = conf;

            // cargamos la configuracion
            this.temporizador.Interval = this.conf.getIntervalMs();
            this.SelectedPath = this.conf.getPath();
            this.db = this.conf.getDataBase();

            // restauramos la configuracion para conectarse al servidor de Sql Server
            SQLServer sqlserver = new SQLServer(this.conf.getHost(), this.conf.getUser(), this.conf.getPassword(), this.conf.getDataBase());

            if (sqlserver.testConnection())
            {
                // si tenemos conexion con la base de datos
                this.dbxml = new DBtoXML(sqlserver.getConnection()); // restauramos la conexion
                this.tablesExport = this.conf.getTableNames(); // y restauramos las tablas que se tienen que exportar
            }
            else
            {
                Alert.Warning("No se ha podido configurar porque ha fallado la conexion con el servidor de bases de datos. El Programa no se ejecutara");
                this.confirmConfigDelete();
                return false;
            }

            this.isConfigured = true; // indicamos que ya se ha cargado una cofiguracion
            return true;
        }

        public void StartExport()
        {

        }

        private int CheckTables()
        {
            int tablesExists = 0;

            if(this.tableList.Count > 0 && this.tablesExport.Count > 0)
            {
                for (int i = 0; i < this.tablesExport.Count; i++)
                {
                    for (int z = 0; z < this.tableList.Count; z++)
                    {
                        if(tablesExport[i] == tableList[z])
                        {
                            tablesExists++;
                        }
                    }
                }

                return tablesExists;
            }
            else
            {
                return -1;
            }
        }

        private void confirmConfigDelete()
        {
            string title = "¿Eliminar configuracion?";
            string msg = "¿Quieres eliminar la configuracion actual para crear una configuracion nueva mas tarde?";

            if (Alert.Confirm(title, msg))
            {
                if (this.conf.Delete())
                {
                    Alert.Info("Se ha eliminado la configuracion con exito");
                }
                else
                {
                    Alert.Warning("No se ha podido eliminar la configuracion!");
                }
            }
        }

        private void restoreCheckedTables()
        {
            
            this.tableExportList.SetItemChecked(1, true);
        }

        private void DeleteConfigBtn_Click(object sender, EventArgs e)
        {
            string title = "¿Eliminar configuracion?";
            string msg = "¿Estas seguro de eliminar esta configuracion?";

            if(Alert.Confirm(title, msg))
            {
                if (this.conf.Delete())
                {
                    Alert.Info("Se ha eliminado la configuracion con exito");
                    this.DeleteConfigBtn.Enabled = false; // desactivamos el boton despues de eliminar el archivo de configuracion
                }
                else
                {
                    Alert.Warning("No se ha podido eliminar la configuracion!");
                }
            }
        }

        private bool hasConfigFile()
        {
            try
            {
                System.IO.File.Open("config.xml", System.IO.FileMode.Open);
                return true;
            }
            catch(System.IO.IOException ioe)
            {
                Console.WriteLine(ioe.Message);
                return false;
            }
        }

        private void StopAndExitBtn_Click(object sender, EventArgs e)
        {
            if(this.temporizador.Enabled)
            {
                if (Alert.Confirm("¿Salir?", "¿Parar el proceso y salir de la aplicacion?"))
                {
                    this.StopAndExit();
                }
            }
            else
            {
                this.noClose = false;
                Application.Exit();
            }
        }
    }
}
