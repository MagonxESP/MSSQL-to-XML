using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace AgoraXML
{
    public class Config
    {
        private XmlElement DB;
        private XmlElement User;
        private XmlElement Password;
        private XmlElement Host;
        private XmlElement Tables;
        private XmlElement IntervalMs;
        private XmlElement Path;
        private XmlDocument conf = new XmlDocument();
        private List<string> tableNames = new List<string>();

        public Config() { }

        public Config(string db, string user, string password, string host, List<string> tables, int intervalMs, string path)
        {
            this.setDataBase(db);
            this.setUser(user);
            this.setPassword(password);
            this.setHost(host);
            this.setTablesToExport(tables);
            this.setIntervalMs(intervalMs);
            this.setPath(path);
        }

        public bool Delete()
        {
            try
            {
                File.Delete("config.xml");
                return true;
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
                return false;
            }
        }

        public void Load()
        {
            try
            {
                FileStream fileStream = new FileStream("config.xml", FileMode.Open);

                this.conf.Load(fileStream);

                // extraemos los datos de los nodos
                this.DB = (XmlElement) this.conf.SelectSingleNode("Config/Db");
                this.User = (XmlElement) this.conf.SelectSingleNode("Config/User");
                this.Password = (XmlElement) this.conf.SelectSingleNode("Config/Password");
                this.Host = (XmlElement) this.conf.SelectSingleNode("Config/Host");
                this.IntervalMs = (XmlElement) this.conf.SelectSingleNode("Config/IntervalMs");
                this.Path = (XmlElement) this.conf.SelectSingleNode("Config/Path");

                // extraemos las tablas que se van a exportar
                XmlNodeList tables = this.conf.SelectNodes("Config/Tables/Table");

                if(tables.Count > 0)
                {
                    for(int i = 0; i < tables.Count; i++)
                    {
                        this.tableNames.Add(tables[i].InnerText);
                    }
                }
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        public bool Save()
        {
            FileStream confFile = new FileStream("config.xml", FileMode.OpenOrCreate);
            XmlTextWriter xmlWriter = new XmlTextWriter(confFile, Encoding.UTF8);

            try
            {
                XmlElement root = this.conf.CreateElement("Config");
                // agregamos los nodos al nodo principal
                root.AppendChild(this.DB);
                root.AppendChild(this.User);
                root.AppendChild(this.Password);
                root.AppendChild(this.Host);
                root.AppendChild(this.IntervalMs);
                root.AppendChild(this.Path);
                root.AppendChild(this.Tables);

                // agregamos el nodo principal al documento
                this.conf.AppendChild(root);

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
                this.Tables = this.conf.CreateElement("Tables");

                for (int i = 0; i < tables.Count; i++)
                {
                    // creamos un elemento
                    XmlElement table = this.conf.CreateElement("Table");
                    // le damos un valor
                    table.InnerText = tables[i];
                    // lo añadimos al elemento tables
                    this.Tables.AppendChild(table);
                }
            }
        }

        public void setDataBase(string db)
        {
            this.DB = this.conf.CreateElement("Db");
            this.DB.InnerText = db;
        }

        public void setUser(string user)
        {
            this.User = this.conf.CreateElement("User");
            this.User.InnerText = user;
        }

        public void setPassword(string pass)
        {
            this.Password = this.conf.CreateElement("Password");
            this.Password.InnerText = pass;
        }

        public void setHost(string host)
        {
            this.Host = this.conf.CreateElement("Host");
            this.Host.InnerText = host;
        }

        public void setIntervalMs(int milliseconds)
        {
            this.IntervalMs = this.conf.CreateElement("IntervalMs");
            this.IntervalMs.InnerText = milliseconds.ToString();
        }

        public void setPath(string path)
        {
            this.Path = this.conf.CreateElement("Path");
            this.Path.InnerText = path;
        }

        public string getDataBase()
        {
            return this.DB.InnerText;
        }

        public string getUser()
        {
            return this.User.InnerText;
        }

        public string getPassword()
        {
            return this.Password.InnerText;
        }

        public string getHost()
        {
            return this.Host.InnerText;
        }

        public int getIntervalMs()
        {
            return Int32.Parse(this.IntervalMs.InnerText);
        }

        public string getPath()
        {
            return this.Path.InnerText;
        }

        public List<string> getTableNames()
        {
            return this.tableNames;
        }
    }
}
