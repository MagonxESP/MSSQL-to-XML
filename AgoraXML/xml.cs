using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

/**
 * @author MagonxESP
 */

namespace AgoraXML
{
    public class DBtoXML
    {
        private SqlConnection connection;
        private SqlCommand sqlcmd;
        private SqlDataReader result;
        private List<string> tables;
        private bool conectionFailed;

        public DBtoXML() { }

        public DBtoXML(SqlConnection sqlc) {
            this.connectDB(sqlc);
        }

        public void connectDB(SqlConnection sqlc)
        {
            try
            {
                this.connection = sqlc;
                this.sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Connection = this.connection;
                this.connection.Open();
                this.conectionFailed = false;
            }
            catch(SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                this.conectionFailed = true; // si falla la conexion lo indicamos
            }
        }

        private bool execute(string query)
        {
            if (!this.conectionFailed)
            {
                try
                {
                    this.sqlcmd.CommandText = query;
                    this.result = this.sqlcmd.ExecuteReader();
                    return true;
                }
                catch (SqlException sqle)
                {
                    Console.WriteLine(sqle.Message);
                }
            }

            return false;
        }

        public List<string> getTables()
        {
            this.tables = new List<string>(); // instanciamos la lista de tablas
            string command = "SELECT CAST(table_name as varchar) FROM INFORMATION_SCHEMA.TABLES";

            if (this.execute(command))
            {
                while (this.result.Read())
                {
                    for (int i = 0; i < this.result.FieldCount; i++)
                    {
                        this.tables.Add((string)this.result.GetValue(i));
                    }
                }

                this.result.Close(); // cerramos el reader actual
                return this.tables;
            }

            // si la conexion habia fallado y no se ha podido ejecutar la query
            // devolvemos una lista vacia
            return new List<string>();
        }

        public string tableToXml(string table)
        {
            string xmlstring = "";
            string command = "SELECT * FROM " + table + " FOR XML PATH('" + table + "'), ROOT('" + table + "s')";

            if(this.execute(command))
            {
                while (this.result.Read())
                {
                    for (int i = 0; i < this.result.FieldCount; i++)
                    {
                        xmlstring += (string)this.result.GetValue(i);
                    }
                }

                this.result.Close(); // cerramos el reader actual
                return xmlstring;
            }

            return "";
        }

        public string tablesToXml(string root)
        {
            string XmlDB = "<" + root + ">"; // comenzamos con el nodo principal

            if(this.tables == null)
            {
                this.getTables();
            }

            for(int i = 0; i < tables.Count; i++)
            {
                XmlDB += this.tableToXml(tables[i]);
            }

            XmlDB += "</" + root + ">";
            return XmlDB;
        }

        public static void WriteXmlStringToFile(string path, string xmlstring)
        {
            try
            {
                if (path != null && xmlstring != null)
                {
                    File.WriteAllText(path, xmlstring);
                }
                else
                {
                    Console.WriteLine("Debes poner una ruta y un xml antes de intentar crear un fichero");
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        public bool ConectionStatus()
        {
            return this.conectionFailed;
        }

        public void close()
        {
            this.connection.Close();
        }
    }
}
