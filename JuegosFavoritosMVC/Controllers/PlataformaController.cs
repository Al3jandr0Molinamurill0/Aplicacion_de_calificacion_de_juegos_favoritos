using System.Collections.Generic;
using System.Data.SqlClient;
using JuegosFavoritosMVC.Data;
using JuegosFavoritosMVC.Models;

namespace JuegosFavoritosMVC.Controllers
{
    public class PlataformaController
    {
        public List<Plataforma> Listar()
        {
            List<Plataforma> lista = new List<Plataforma>();

            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Plataformas", cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Plataforma
                    {
                        IdPlataforma = (int)dr["IdPlataforma"],
                        NombrePlataforma = dr["NombrePlataforma"].ToString(),
                        Fabricante = dr["Fabricante"].ToString()
                    });
                }
            }
            return lista;
        }

        public void Insertar(Plataforma p)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Plataformas VALUES (@Nombre,@Fabricante)", cn);

                cmd.Parameters.AddWithValue("@Nombre", p.NombrePlataforma);
                cmd.Parameters.AddWithValue("@Fabricante", p.Fabricante);

                cmd.ExecuteNonQuery();
            }
        }

        public void Editar(Plataforma p)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Plataformas 
                      SET NombrePlataforma=@Nombre, Fabricante=@Fabricante 
                      WHERE IdPlataforma=@Id", cn);

                cmd.Parameters.AddWithValue("@Nombre", p.NombrePlataforma);
                cmd.Parameters.AddWithValue("@Fabricante", p.Fabricante);
                cmd.Parameters.AddWithValue("@Id", p.IdPlataforma);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Plataformas WHERE IdPlataforma=@Id", cn);

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
