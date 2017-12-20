using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace mssqltoxml
{
    public class Config
    {
        private string DB;
        private string User;
        private string Password;
        private string Host;
        private int IntervalMs;
        private string Path;
        private XmlDocument conf = new XmlDocument();
        private List<string> tableNames = new List<string>();
        private List<XmlElement> elements = new List<XmlElement>();

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

        public bool Load()
        {
            try
            {
                FileStream fileStream = new FileStream("config.xml", FileMode.Open);

                try
                {
                    this.conf.Load(fileStream);

                    // extraemos los datos de los nodos
                    this.DB = this.conf.SelectSingleNode("/Config/Db").InnerText;
                    this.User = this.conf.SelectSingleNode("/Config/User").InnerText;
                    this.Password = this.conf.SelectSingleNode("/Config/Password").InnerText;
                    this.Host = this.conf.SelectSingleNode("/Config/Host").InnerText;
                    this.IntervalMs = Int32.Parse(this.conf.SelectSingleNode("/Config/IntervalMs").InnerText);
                    this.Path = this.conf.SelectSingleNode("/Config/Path").InnerText;

                    // extraemos las tablas que se van a exportar
                    XmlNodeList tables = this.conf.SelectNodes("/Config/Tables/Table");

                    if (tables.Count > 0)
                    {
                        for (int i = 0; i < tables.Count; i++)
                        {
                            this.tableNames.Add(tables[i].InnerText);
                        }
                    }
                }
                catch(XmlException xmle)
                {
                    Console.WriteLine(xmle.Message);
                    return false;
                }
                
                fileStream.Flush();
                fileStream.Close();

                return true;
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                FileStream confFile = new FileStream("config.xml", FileMode.OpenOrCreate);
                
                try
                {
                    XmlTextWriter xmlWriter = new XmlTextWriter(confFile, Encoding.UTF8);

                    if (this.conf.DocumentElement != null)
                    {
                        // si el documento ya tiene un nodo raiz
                        // creamos un documento nuevo machacando todo su contenido
                        this.conf = new XmlDocument();
                    }
                    
                    // preparamos los nodos
                    this.setNodesValues();

                    // los añadimos al nodo raiz del documento
                    XmlElement root = this.CreateDocumentNodeAndAppendChildNodes();

                    // agregamos el nodo raiz al documento
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
                catch (XmlException xmle)
                {
                    Console.WriteLine(xmle.Message);
                    return false;
                }
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
                return false;
            }
        }

        private XmlElement CreateDocumentNodeAndAppendChildNodes()
        {
            XmlElement documentNode = this.conf.CreateElement("Config");

            if(elements.Count > 0)
            {
                for(int i = 0; i < elements.Count; i++)
                {
                    documentNode.AppendChild(elements[i]);
                }
            }

            return documentNode;
        }

        private void setNodesValues()
        {
            // creamos los elementos nuevos
            XmlElement DB = this.conf.CreateElement("Db");
            XmlElement User = this.conf.CreateElement("User");
            XmlElement Password = this.conf.CreateElement("Password");
            XmlElement Host = this.conf.CreateElement("Host");
            XmlElement Tables = this.conf.CreateElement("Tables");
            XmlElement IntervalMs = this.conf.CreateElement("IntervalMs");
            XmlElement Path = this.conf.CreateElement("Path");

            // les damos su valor
            DB.InnerText = this.DB;
            User.InnerText = this.User;
            Password.InnerText = this.Password;
            Host.InnerText = this.Host;
            Tables = this.createTableListNode();
            IntervalMs.InnerText = this.IntervalMs.ToString();
            Path.InnerText = this.Path;

            // los añadimos a nuestra lista de elementos
            this.elements.Add(DB);
            this.elements.Add(User);
            this.elements.Add(Password);
            this.elements.Add(Host);
            this.elements.Add(Path);
            this.elements.Add(IntervalMs);
            this.elements.Add(Tables);
        }

        private XmlElement createTableListNode()
        {
            XmlElement TablesNode = this.conf.CreateElement("Tables");

            if (this.tableNames.Count > 0)
            {
                for (int i = 0; i < this.tableNames.Count; i++)
                {
                    // creamos un elemento
                    XmlElement table = this.conf.CreateElement("Table");
                    // le damos un valor
                    table.InnerText = this.tableNames[i];
                    // lo añadimos al elemento tables
                    TablesNode.AppendChild(table);
                }
            }

            return TablesNode;
        }

        public void setTablesToExport(List<string> tables)
        {
            this.tableNames = tables;
        }

        public void setDataBase(string db)
        {
            this.DB = db;
        }

        public void setUser(string user)
        {
            this.User = user;
        }

        public void setPassword(string pass)
        {
            this.Password = pass;
        }

        public void setHost(string host)
        {
            this.Host = host;
        }

        public void setIntervalMs(int milliseconds)
        {
            this.IntervalMs = milliseconds;
        }

        public void setPath(string path)
        {
            this.Path = path;
        }

        public string getDataBase()
        {
            return this.DB;
        }

        public string getUser()
        {
            return this.User;
        }

        public string getPassword()
        {
            return this.Password;
        }

        public string getHost()
        {
            return this.Host;
        }

        public int getIntervalMs()
        {
            return this.IntervalMs;
        }

        public string getPath()
        {
            return this.Path;
        }

        public List<string> getTableNames()
        {
            return this.tableNames;
        }
    }
}
