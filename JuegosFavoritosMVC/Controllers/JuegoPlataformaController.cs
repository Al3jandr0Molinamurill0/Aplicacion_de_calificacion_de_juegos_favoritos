using System.Data.SqlClient;
using System.Data;
using JuegosFavoritosMVC.Data;
using System;
using JuegosFavoritosMVC.Models;

namespace JuegosFavoritosMVC.Controllers
{
    public class JuegoPlataformaController
    {
        public void Asignar(int idJuego, int idPlataforma, DateTime fecha)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO JuegosPlataformas
            (IdJuego, IdPlataforma, FechaLanzamientoPlataforma)
            VALUES (@Juego, @Plataforma, @Fecha)", cn);

                cmd.Parameters.AddWithValue("@Juego", idJuego);
                cmd.Parameters.AddWithValue("@Plataforma", idPlataforma);
                cmd.Parameters.AddWithValue("@Fecha", fecha);

                cmd.ExecuteNonQuery();
            }
        }

        public void Quitar(int idJuego, int idPlataforma)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"
            DELETE FROM JuegosPlataformas
            WHERE IdJuego = @Juego AND IdPlataforma = @Plataforma", cn);

                cmd.Parameters.AddWithValue("@Juego", idJuego);
                cmd.Parameters.AddWithValue("@Plataforma", idPlataforma);

                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ListarPorJuego(int idJuego)
        {
            return JuegoPlataformaModel.ListarPorJuego(idJuego);
        }

        public bool ExisteAsignacion(int idJuego, int idPlataforma)
        {
            return JuegoPlataformaModel.ExisteAsignacion(idJuego, idPlataforma);
        }

    }
}
