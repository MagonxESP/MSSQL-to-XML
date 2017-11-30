using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgoraXML
{
    public partial class Form1 : Form
    {
        private string sqlserver;
        private string database;
        private string user;
        private string password;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.initHostsDropDown();
        }

        private void initHostsDropDown()
        {
            List<string> servers = SQLServer.getHosts();

            if(servers.Count > 0)
            {
                for (int i = 0; i < servers.Count; i++)
                {
                    hostsDropDown.Items.Add(servers[i]);
                }
            }
            else
            {
                Alert.Warning("No se han encontrado servidores de Microsoft SQL Server");
            }
            
        }

        private void hostsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sqlserver = (string) hostsDropDown.SelectedItem;
            SQLServer servidor = new SQLServer(this.sqlserver);

            List<string> dbs = servidor.getDataBases();
            dbDropDown.Items.Clear(); // limpiamos la lista de bases de datos

            if(dbs.Count > 0)
            {
                for (int i = 0; i < dbs.Count; i++)
                {
                    dbDropDown.Items.Add(dbs[i]);
                }
            }
            else
            {
                Alert.Warning("No se han encontrado bases de datos en este servidor");
            }
        }

        private void dbDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.database = (string) dbDropDown.SelectedItem;
        }

        private void testConnectionBtn_Click(object sender, EventArgs e)
        {
            this.user = userInput.Text;
            this.password = passwordInput.Text;

            SQLServer server = new SQLServer(this.sqlserver, this.user, this.password, this.database);

            if (server.testConnection())
            {
                Alert.Info("La conexion con la base de datos es correcta");
            }
            else
            {
                Alert.Warning("No se puede conectar con el servidor o con la base de datos :(");
            }
        }

        private void conexionBtn_Click(object sender, EventArgs e)
        {
            this.user = userInput.Text;
            this.password = passwordInput.Text;

            Form dbform = new Form2();

            SQLServer server = new SQLServer(this.sqlserver, this.user, this.password, this.database);

            if (server.testConnection())
            {
                Program.dbxml = new DBtoXML(server.getConnection());
                Program.dbName = this.database;
                dbform.Show();
                this.Hide();
            }
            else
            {
                Alert.Warning("Error al conectarse con la base de datos");
            }
        }

        private void connectSilentModeBtn_Click(object sender, EventArgs e)
        {
            this.user = userInput.Text;
            this.password = passwordInput.Text;

            Form standAloneForm = new Standalone(); // formulario para programar el modo silencioso

            SQLServer server = new SQLServer(this.sqlserver, this.user, this.password, this.database);

            if (server.testConnection())
            {
                Program.dbxml = new DBtoXML(server.getConnection());
                Program.dbName = this.database;
                standAloneForm.Show();
                this.Hide();                
            }
            else
            {
                Alert.Warning("Error al conectarse con la base de datos");
            }
        }
    }
}
