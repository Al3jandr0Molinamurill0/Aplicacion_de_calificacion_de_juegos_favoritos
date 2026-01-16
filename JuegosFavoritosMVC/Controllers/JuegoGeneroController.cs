using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegosFavoritosMVC.Data;
using JuegosFavoritosMVC.Models;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace JuegosFavoritosMVC.Controllers
{
    public class JuegoGeneroController
    {
        public void Asignar(int idJuego, int idGenero)
        {
            JuegoGeneroModel.Asignar(idJuego, idGenero);
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(
                    @"IF NOT EXISTS (
                SELECT 1 
                FROM JuegosGeneros 
                WHERE IdJuego = @Juego AND IdGenero = @Genero
            )
            BEGIN
                INSERT INTO JuegosGeneros (IdJuego, IdGenero)
                VALUES (@Juego, @Genero)
            END", cn);

                cmd.Parameters.AddWithValue("@Juego", idJuego);
                cmd.Parameters.AddWithValue("@Genero", idGenero);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarGenerosPorJuego(int idJuegos)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT 
                g.IdGenero,
                g.NombreGenero,
                g.Descripcion
              FROM JuegosGeneros jg
              INNER JOIN Generos g ON jg.IdGenero = g.IdGenero
              WHERE jg.IdJuego = @IdJuego", cn);

                cmd.Parameters.AddWithValue("@IdJuego", idJuegos);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public void Quitar(int idJuego, int idGenero)
        {
            JuegoGeneroModel.Quitar(idJuego, idGenero);
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"DELETE FROM JuegosGeneros 
              WHERE IdJuego = @Juego AND IdGenero = @Genero", cn);
                cmd.Parameters.AddWithValue("@Juego", idJuego);
                cmd.Parameters.AddWithValue("@Genero", idGenero);
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ListarJuegosConGeneros()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
              SqlCommand cmd = new SqlCommand(
            @"SELECT 
                j.NombreDelJuego AS Juego,
                g.NombreGenero AS Genero
              FROM JuegosGeneros jg
              INNER JOIN Juegos j ON jg.IdJuego = j.IdJuego
              INNER JOIN Generos g ON jg.IdGenero = g.IdGenero
              ORDER BY j.NombreDelJuego", cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public bool ExisteAsignacion(int idJuego, int idGenero)
        {
            return JuegoGeneroModel.ExisteAsignacion(idJuego, idGenero);
        }
    }
}
