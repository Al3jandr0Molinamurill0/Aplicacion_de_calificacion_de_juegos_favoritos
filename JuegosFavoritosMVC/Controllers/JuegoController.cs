using JuegosFavoritosMVC.Data;
using JuegosFavoritosMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace JuegosFavoritosMVC.Controllers
{
    public class JuegoController
    {
        public void Insertar(Juego j)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Juegos 
                    (NombreDelJuego, Creador, AnioLanzamiento, Distribuidora) 
                    VALUES (@Nombre,@Creador,@Anio,@Distribuidora)", cn);

                cmd.Parameters.AddWithValue("@Nombre", j.NombreDelJuego);
                cmd.Parameters.AddWithValue("@Creador", j.Creador);
                cmd.Parameters.AddWithValue("@Anio", j.AnioLanzamiento);
                cmd.Parameters.AddWithValue("@Distribuidora", j.Distribuidora);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Juego> Listar()
        {
            List<Juego> lista = new List<Juego>();

            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Juegos", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Juego
                    {
                        IdJuego = (int)dr["IdJuego"],
                        NombreDelJuego = dr["NombreDelJuego"].ToString(),
                        Creador = dr["Creador"].ToString(),
                        AnioLanzamiento = (int)dr["AnioLanzamiento"],
                        Distribuidora = dr["Distribuidora"].ToString(),
                        FechaRegistro = (DateTime)dr["FechaRegistro"]
                    });
                }
            }
            return lista;
        }

        public void Actualizar(Juego j)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Juegos SET 
                    NombreDelJuego=@Nombre, Creador=@Creador, 
                    AnioLanzamiento=@Anio, Distribuidora=@Distribuidora 
                    WHERE IdJuego=@Id", cn);
                cmd.Parameters.AddWithValue("@Nombre", j.NombreDelJuego);
                cmd.Parameters.AddWithValue("@Creador", j.Creador);
                cmd.Parameters.AddWithValue("@Anio", j.AnioLanzamiento);
                cmd.Parameters.AddWithValue("@Distribuidora", j.Distribuidora);
                cmd.Parameters.AddWithValue("@Id", j.IdJuego);
                cmd.ExecuteNonQuery();
            }
        }
        public void Eliminar(int idJuego)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Juegos WHERE IdJuego=@Id", cn);
                cmd.Parameters.AddWithValue("@Id", idJuego);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
