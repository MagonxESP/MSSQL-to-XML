using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace AgoraXML
{
    class Config
    {
        private XmlElement DB;
        private XmlElement User;
        private XmlElement Password;
        private XmlElement Host;
        private XmlElement Tables;
        private XmlDocument conf = new XmlDocument();

        public Config() { }

        public Config(string db, string user, string password, string host, List<string> tables)
        {
            this.setDataBase(db);
            this.setUser(user);
            this.setPassword(password);
            this.setHost(host);
            this.setTablesToExport(tables);
        }

        public void Load()
        {
            try
            {
                FileStream fileStream = new FileStream("conf.xml", FileMode.Open);

                this.conf.Load(fileStream);

                // queda extraer los datos
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        public bool Save()
        {
            FileStream confFile = new FileStream("conf.xml", FileMode.OpenOrCreate);
            XmlTextWriter xmlWriter = new XmlTextWriter(confFile, Encoding.UTF8);

            try
            {
                // agregamos los nodos al documento
                this.conf.AppendChild(this.DB);
                this.conf.AppendChild(this.User);
                this.conf.AppendChild(this.Password);
                this.conf.AppendChild(this.Host);
                this.conf.AppendChild(this.Tables);

                // establecemos con que formato debe escribir el fichero xml
                xmlWriter.Formatting = Formatting.Indented;

                // escribimos el documento en el fichero
                this.conf.WriteTo(xmlWriter);

                // limpiamos el buffer
                xmlWriter.Flush();
                confFile.Flush();

                // cerramos el fichero
                xmlWriter.Close();
                confFile.Close();
                return true;
            }
            catch(XmlException xmle)
            {
                Console.WriteLine(xmle.Message);
                return false;
            }
        }

        public void setTablesToExport(List<string> tables)
        {
            if(tables.Count > 0)
            {
                this.Tables = this.conf.CreateElement("tables");

                for (int i = 0; i < tables.Count; i++)
                {
                    // creamos un elemento
                    XmlElement table = this.conf.CreateElement("table");
                    // le damos un valor
                    table.Value = tables[i];
                    // lo añadimos al elemento tables
                    this.Tables.AppendChild(table);
                }
            }
        }

        public void setDataBase(string db)
        {
            this.DB = this.conf.CreateElement("db");
            this.DB.Value = db;
        }

        public void setUser(string user)
        {
            this.User = this.conf.CreateElement("user");
            this.User.Value = user;
        }

        public void setPassword(string pass)
        {
            this.Password = this.conf.CreateElement("password");
            this.Password.Value = pass;
        }

        public void setHost(string host)
        {
            this.Host = this.conf.CreateElement("host");
            this.Host.Value = host;
        }

        public string getDataBase()
        {
            return this.DB.Value;
        }

        public string getUser()
        {
            return this.User.Value;
        }

        public string getPassword()
        {
            return this.Password.Value;
        }

        public string getHost()
        {
            return this.Host.Value;
        }
    }
}
