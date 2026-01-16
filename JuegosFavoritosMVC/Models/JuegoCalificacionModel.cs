using System.Data;
using System.Data.SqlClient;
using JuegosFavoritosMVC.Data;

namespace JuegosFavoritosMVC.Models
{
    public class JuegoCalificacionModel
    {
        public static DataTable ListarCalificaciones()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                j.NombreDelJuego,
                r.Calificacion,
                r.Razon,
                r.FechaOpinion
            FROM Razones r
            INNER JOIN Juegos j ON r.IdJuego = j.IdJuego", cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

    }
}
