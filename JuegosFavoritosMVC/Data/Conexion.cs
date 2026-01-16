using System.Data.SqlClient;
using System.Configuration;
using System;

namespace JuegosFavoritosMVC.Data
{
    public class Conexion
    {
        public static SqlConnection GetConexion()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["JuegosFavoritos"].ConnectionString
            );
        }

    }
}
