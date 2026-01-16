using JuegosFavoritosMVC.Data;
using JuegosFavoritosMVC.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace JuegosFavoritosMVC.Controllers
{
    // Controlador responsable de las operaciones CRUD y consultas
    // relacionadas con las calificaciones (tabla Razones).
    public class CalificacionController
    {
       /// <summary>
       /// Inserta una nueva calificación (razón) para un juego.
       /// - idJuego: clave foránea hacia la tabla Juegos.
       /// - calificacion: valor numérico de la calificación.
       /// - razon: texto explicando la razón de la calificación.
       /// - fecha: fecha de la opinión.
       /// Observaciones:
       /// - Se usa un bloque using para asegurar el cierre/disposing de la conexión.
       /// - Se usan parámetros para evitar inyección SQL; sin embargo, usar AddWithValue
       ///   puede provocar conversiones de tipo inesperadas — considerar SqlParameter con DbType explícito.
       /// </summary>
       public void Agregar(int idJuego, int calificacion, string razon, DateTime fecha)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                     @"INSERT INTO Razones (IdJuego, Calificacion, Razon, FechaOpinion)
                      VALUES (@IdJuego, @Calificacion, @Razon, @Fecha)", cn);

                // Parámetros enlazados al comando
                cmd.Parameters.AddWithValue("@IdJuego", idJuego);
                cmd.Parameters.AddWithValue("@Calificacion", calificacion);
                cmd.Parameters.AddWithValue("@Razon", razon);
                cmd.Parameters.AddWithValue("@Fecha", fecha);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Devuelve las calificaciones para un juego específico.
        /// Retorna un DataTable con columnas: NombreDelJuego, Calificacion, Razon, FechaOpinion.
        /// Atención:
        /// - La consulta realiza un JOIN con la tabla Juegos para incluir el nombre del juego.
        /// - La vista que enlaza este DataTable debe esperar exactamente esos nombres de columna.
        /// </summary>
        public DataTable ListarPorJuego(int idJuego) 
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                     @"SELECT j.NombreDelJuego, r.Calificacion, r.Razon, r.FechaOpinion
                       FROM Razones r
                       INNER JOIN Juegos j ON r.IdJuego = j.IdJuego
                       WHERE r.IdJuego = @IdJuego", cn);

                // Añadir parámetro y llenar el DataTable
                cmd.Parameters.AddWithValue("@IdJuego", idJuego);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Verifica si ya existe una calificación para el juego dado.
        /// Devuelve true si el conteo es mayor que cero.
        /// </summary>
        public bool ExisteCalificacion (int idJuego)
        {
            using (SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                   "SELECT COUNT(*) FROM Razones WHERE IdJuego = @IdJuego", cn);
                cmd.Parameters.AddWithValue("@IdJuego", idJuego);
              return (int)cmd.ExecuteScalar() > 0;
            }
        }

        /// <summary>
        /// Calcula y devuelve el promedio de las calificaciones para un juego.
        /// - Si no hay filas, ExecuteScalar devuelve DBNull.Value y se retorna 0.
        /// - Convert.ToDecimal se usa para mapear el resultado a decimal.
        /// </summary>
        public decimal ObtenerPromedio(int idJuego) 
        {
            using(SqlConnection cn = Conexion.GetConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                   "SELECT AVG(Calificacion) FROM Razones WHERE IdJuego = @IdJuego", cn);
                cmd.Parameters.AddWithValue("@IdJuego", idJuego);
                object result = cmd.ExecuteScalar();
                return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
            }
        }

        /// <summary>
        /// Devuelve todas las calificaciones usando el model `JuegoCalificacionModel`.
        /// Nota: Se delega la implementación a la capa de modelos; revisar ese método
        /// si se requieren columnas o formatos específicos.
        /// </summary>
        public DataTable ListarTodo()
        {
            return JuegoCalificacionModel.ListarCalificaciones();
        }
        
    }
}
