using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegosFavoritosMVC.Controllers;


namespace JuegosFavoritosMVC.Views
{
    public partial class FrmCalificacion : Form
    {
        JuegoController juegoController = new JuegoController();
        CalificacionController calificacionController = new CalificacionController();

        public FrmCalificacion()
        {
            InitializeComponent();
            CargarJuegos();
        }
        void CargarJuegos()
        {
            cmbJuegos.DataSource = juegoController.Listar();
            cmbJuegos.DisplayMember = "NombreDelJuego";
            cmbJuegos.ValueMember = "IdJuego";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idJuego = Convert.ToInt32(cmbJuegos.SelectedValue);
            int calificacion = Convert.ToInt32(nudCalificacion.Value);

            if (calificacionController.ExisteCalificacion(idJuego))
            {
                MessageBox.Show("Este juego ya tiene una calificación registrada.");
                return;
            }

            calificacionController.Agregar(
                idJuego,
                calificacion,
                txtRazon.Text,
                dtpFecha.Value
            );

            MessageBox.Show("Calificación guardada correctamente.");
            CargarCalificaciones();
        }
        void CargarCalificaciones()
        {
            if (!int.TryParse(cmbJuegos.SelectedValue?.ToString(), out int idJuego))
                return;

            dgvCalificaciones.DataSource =
                calificacionController.ListarPorJuego(idJuego);

            decimal promedio =
                calificacionController.ObtenerPromedio(idJuego);

            lblPromedio.Text = "Promedio: " + promedio.ToString("0.0");

            if (dgvCalificaciones.Columns.Contains("NombreDelJuego"))
                dgvCalificaciones.Columns["NombreDelJuego"].Width = 200;
            if (dgvCalificaciones.Columns.Contains("Calificacion"))
                dgvCalificaciones.Columns["Calificacion"].Width = 90;
            if (dgvCalificaciones.Columns.Contains("Razon"))
                dgvCalificaciones.Columns["Razon"].Width = 250;
            if (dgvCalificaciones.Columns.Contains("FechaOpinion"))
                dgvCalificaciones.Columns["FechaOpinion"].Width = 120;
        }


        private void cmbJuegos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJuegos.SelectedValue is int idJuego)
            {
                decimal promedio = calificacionController.ObtenerPromedio(idJuego);
                lblPromedio.Text = "Calificación Promedio: " + promedio.ToString("0.0");
            }
        }

        private void FrmCalificacion_Load(object sender, EventArgs e)
        {
            CargarJuegos();
            CargarCalificaciones();
        }
    }
}
