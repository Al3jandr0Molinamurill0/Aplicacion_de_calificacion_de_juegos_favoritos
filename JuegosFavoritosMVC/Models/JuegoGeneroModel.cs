using System.Data;
using System.Data.SqlClient;
using JuegosFavoritosMVC.Data;

namespace JuegosFavoritosMVC.Models
{
    public class JuegoGeneroModel
    {
        public static bool ExisteAsignacion(int idJuego, int idGenero)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.JuegosGeneros WHERE IdJuego = @IdJuego AND IdGenero = @IdGenero",
                    cn);

                cmd.Parameters.AddWithValue("@IdJuego", idJuego);
                cmd.Parameters.AddWithValue("@IdGenero", idGenero);

                cn.Open();
                int cantidad = (int)cmd.ExecuteScalar();

                return cantidad > 0;
            }
        }

        public static void Asignar(int idJuego, int idGenero)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO dbo.JuegosGeneros (IdJuego, IdGenero) VALUES (@IdJuego, @IdGenero)",
                    cn);

                cmd.Parameters.AddWithValue("@IdJuego", idJuego);
                cmd.Parameters.AddWithValue("@IdGenero", idGenero);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void Quitar(int idJuego, int idGenero)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM dbo.JuegosGeneros WHERE IdJuego = @IdJuego AND IdGenero = @IdGenero",
                    cn);

                cmd.Parameters.AddWithValue("@IdJuego", idJuego);
                cmd.Parameters.AddWithValue("@IdGenero", idGenero);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}
