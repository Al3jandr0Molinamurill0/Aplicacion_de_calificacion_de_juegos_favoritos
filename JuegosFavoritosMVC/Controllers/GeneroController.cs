using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegosFavoritosMVC.Data;
using JuegosFavoritosMVC.Models;
using System.Data.SqlClient;

namespace JuegosFavoritosMVC.Controllers
{
    public class GeneroController
    {
        public void Insertar(Genero g)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();

                // 🔍 Verificar si el género ya existe
                SqlCommand validar = new SqlCommand(
                    "SELECT COUNT(*) FROM Generos WHERE NombreGenero = @Nombre", cn);
                validar.Parameters.AddWithValue("@Nombre", g.NombreGenero);

                int existe = Convert.ToInt32(validar.ExecuteScalar());

                if (existe > 0)
                {
                    throw new Exception("El género ya existe.");
                }

                // ✔ Insertar si no existe
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Generos (NombreGenero, Descripcion) VALUES (@Nombre, @Descripcion)", cn);

                cmd.Parameters.AddWithValue("@Nombre", g.NombreGenero);
                cmd.Parameters.AddWithValue("@Descripcion", g.Descripcion ?? "");

                cmd.ExecuteNonQuery();
            }
        }

        public List<Genero> Listar()
        {
            List<Genero> lista = new List<Genero>();
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Generos", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Genero
                    {
                        IdGenero = (int)dr["IdGenero"],
                        NombreGenero = dr["NombreGenero"].ToString(),
                        Descripcion = dr["Descripcion"].ToString()
                    });
                }

            }
            return lista;
        }
        public void Eliminar(int idGenero)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Generos WHERE IdGenero=@Id", cn);
                cmd.Parameters.AddWithValue("@Id", idGenero);
                cmd.ExecuteNonQuery();
            }
        }
        public void Actualizar(Genero g)
        {
            using(SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    cmdText: @"UPDATE Generos SET
                NombreGenero= @Nombre,
                Descripcion = @Descripcion
                Where IdGenero = @Id",cn);

                cmd.Parameters.AddWithValue("@Nombre",g.NombreGenero);
                cmd.Parameters.AddWithValue("@Descripcion", g.Descripcion);
                cmd.Parameters.AddWithValue("@Id", g.IdGenero);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
