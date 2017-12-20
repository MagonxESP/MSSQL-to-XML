using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mssqltoxml
{
    static class Program
    {
        public static DBtoXML dbxml;
        public static Form mainForm;
        public static string dbName;
        public static Config conf;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Config conf = new Config();

            if (conf.Load())
            {
                // si se ha podido cargar una configuracion
                Standalone s = new Standalone(); // Instanciamos un StandAlone

                if (s.Configure(conf))
                {
                    // si se ha configurado correctamente arrancamos la aplicacion
                    s.initExportOnLoad = true; // indicamos que comenzamos a exportar cuando este cargado
                    Application.Run(s);
                }
            }
            else
            {
                // si no existe configuracion o no se ha podido cargar
                mainForm = new Form1(); // Instanciamos el formulario principal
                Application.Run(mainForm); // y arrancamos la aplicacion
            }            
        }
    }
}
