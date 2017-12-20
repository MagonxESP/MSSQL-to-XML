using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace mssqltoxml
{
    class SQLServer
    {
        private SqlConnection conexion;
        private SqlCommand sqlcmd;

        public SQLServer() { }

        public SQLServer(string server)
        {
            this.Connect(server);
        }

        public SQLServer(string server, string user, string password, string db)
        {
            this.Connect(server, user, password, db);
        }

        public void Connect(string server)
        {
            string connectionString = "Data Source=" + server + ";Integrated Security=True;Initial Catalog=master";
            this.conexion = new SqlConnection(connectionString);
            this.sqlcmd = new SqlCommand();
            this.sqlcmd.Connection = this.conexion;
            this.sqlcmd.CommandType = CommandType.Text;
        }

        public void Connect(string server, string user, string password, string db)
        {
            string connectionString = "Server=" + server + ";Database=" + db + ";User Id=" + user + ";Password=" + password + ";";
            this.conexion = new SqlConnection(connectionString);
            this.sqlcmd = new SqlCommand();
            this.sqlcmd.Connection = this.conexion;
            this.sqlcmd.CommandType = CommandType.Text;
        }

        public bool testConnection()
        {
            try
            {
                this.conexion.Open();
                this.conexion.Close();
                return true;
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                return false;
            }
        }

        public SqlConnection getConnection()
        {
            return this.conexion;
        }

        public List<string> getDataBases()
        {
            List<string> dbs = new List<string>();
            string comando = "SELECT name FROM sys.databases";

            try
            {
                this.conexion.Open();
                this.sqlcmd.CommandText = comando;
                SqlDataReader result = this.sqlcmd.ExecuteReader();

                while (result.Read())
                {
                    dbs.Add((string) result.GetValue(0));
                }

                this.conexion.Close();
            }
            catch(SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
            }

            return dbs;
        }

        public static List<string> getHosts()
        {
            List<string> hosts = new List<string>();
            SqlDataSourceEnumerator sqlServers = SqlDataSourceEnumerator.Instance;
            DataTable serverNames = sqlServers.GetDataSources();
            
            foreach(DataRow row in serverNames.Rows)
            {
                string instance = "";

                foreach(DataColumn col in serverNames.Columns)
                {
                    if(col.ColumnName == "ServerName")
                    {
                        instance += row[col];
                    }

                    if(col.ColumnName == "InstanceName")
                    {
                        instance += "\\" + row[col]; 
                    }
                }

                hosts.Add(instance);
            }
            
            return hosts;
        }
    }
}
