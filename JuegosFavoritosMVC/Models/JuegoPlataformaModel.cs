using System.Data;
using System.Data.SqlClient;
using JuegosFavoritosMVC.Data;

namespace JuegosFavoritosMVC.Models
{
    public class JuegoPlataformaModel
    {
        public static DataTable ListarPorJuego(int idJuego)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT jp.IdPlataforma,
                           p.NombrePlataforma,
                           jp.FechaLanzamientoPlataforma
                    FROM JuegosPlataformas jp
                    INNER JOIN Plataformas p ON p.IdPlataforma = jp.IdPlataforma
                    WHERE jp.IdJuego = @IdJuego", cn);

                cmd.Parameters.AddWithValue("@IdJuego", idJuego);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static bool ExisteAsignacion(int idJuego, int idPlataforma)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(*) 
                    FROM JuegosPlataformas 
                    WHERE IdJuego = @Juego AND IdPlataforma = @Plataforma", cn);

                cmd.Parameters.AddWithValue("@Juego", idJuego);
                cmd.Parameters.AddWithValue("@Plataforma", idPlataforma);

                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
}

