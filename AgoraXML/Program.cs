using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgoraXML
{
    static class Program
    {
        public static DBtoXML dbxml;
        public static Form mainForm;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new Form1();
            Application.Run(mainForm);

            /*
            string connectionString = "Server=localhost\\agora;Database=igtpos;User Id=sa;Password=igt123;"; //string para conectarse

            DBtoXML dbxml = new DBtoXML(connectionString);

            List<string> tablas = dbxml.getTables();

            for(int i = 0; i < tablas.Count; i++)
            {
                Console.WriteLine(tablas[i]);
            }

            Console.WriteLine("------------- XML Products ---------------");

            string productsxml = dbxml.tablesToXml("Agora");

            Console.WriteLine(productsxml);

            DBtoXML.WriteXmlStringToFile("c:\\Users\\juanma\\Desktop\\agora.xml", productsxml);
            */
        }
    }
}
