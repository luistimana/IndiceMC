using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IndiceMC.Conexion
{
    public class CONEXIONMAESTRA
    {
        public static string conexion = ("Data Source = 192.168.0.15; Initial Catalog = database_appIMC; Integrated Security = false; User Id = root; Password = secret;");
        public static SqlConnection conectar = new SqlConnection(conexion);

        public static void abrir()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }
        public static void cerrar()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}

