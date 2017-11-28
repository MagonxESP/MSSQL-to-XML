using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AgoraDB
{
    class AgoraDB
    {
        public static void Main(String[] args)
        {
            // XML productos = new XML();
            string connectionString = "Server=localhost;Database=igtpos;User Id=sa;Password=igt123;"; //string para conectarse

            SqlConnection conexion = new SqlConnection(connectionString);
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataReader result;

            sqlcmd.CommandText = "SELECT * FROM Product FOR XML PATH ('Product'), ROOT('Products')";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = conexion;

            conexion.Open(); // abrimos la conexion a la base de datos

            result = sqlcmd.ExecuteReader(); // ejecutamos la query

            Console.WriteLine(result);
            
            conexion.Close(); // cerramos la conexion
        }
    }
}
