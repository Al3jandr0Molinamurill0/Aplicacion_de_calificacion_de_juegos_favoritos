using JuegosFavoritosMVC.Controllers;
using JuegosFavoritosMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JuegosFavoritosMVC.Views
{
    
    public partial class FrmAsignarGenero : Form
    {
        JuegoController juegoController = new JuegoController();
        GeneroController generoController = new GeneroController();
        JuegoGeneroController asignacionController = new JuegoGeneroController();
        JuegoGeneroController controllerJG = new JuegoGeneroController();
        int idJuegoSeleccionado = 0;
        public FrmAsignarGenero()
        {
            InitializeComponent();
            CargarDatos();
            CargarResumen();

            dgvAsignaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAsignaciones.MultiSelect = false;
            dgvAsignaciones.ReadOnly = true;

            CargarDatos();
            CargarResumen();
        }
        void CargarResumen()
        {
            dgvResumen.DataSource =
                controllerJG.ListarJuegosConGeneros();
        }

        void CargarDatos()
        {
            cmbJuegos.DataSource = juegoController.Listar();
            cmbJuegos.DisplayMember = "NombreDelJuego";
            cmbJuegos.ValueMember = "IdJuego";

            cmbGeneros.DataSource = generoController.Listar();
            cmbGeneros.DisplayMember = "NombreGenero";
            cmbGeneros.ValueMember = "IdGenero";
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            int idJuego = Convert.ToInt32(cmbJuegos.SelectedValue);
            int idGenero = Convert.ToInt32(cmbGeneros.SelectedValue);

            if (controllerJG.ExisteAsignacion(idJuego, idGenero))
            {
                MessageBox.Show("Este juego ya tiene asignado ese género.");
                return;
            }

            controllerJG.Asignar(idJuego, idGenero);

            MessageBox.Show("Género asignado correctamente.");

            CargarGenerosAsignados(idJuego);
            CargarResumen();
        }

        private void dgvAsignaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        void CargarGenerosAsignados(int idJuego)
        {
            if (idJuego > 0)
            {
                dgvAsignaciones.DataSource =
                    controllerJG.ListarGenerosPorJuego(idJuego);
            }
        }


        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvAsignaciones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un género para quitar.");
                return;
            }

            int idGenero = Convert.ToInt32(
                dgvAsignaciones.CurrentRow.Cells["IdGenero"].Value);

            int idJuego = Convert.ToInt32(cmbJuegos.SelectedValue);

            asignacionController.Quitar(idJuego, idGenero);

            MessageBox.Show("Género quitado del juego correctamente.");

            CargarGenerosAsignados(idJuego); // Grid superior
            CargarResumen();                 // 🔥 Grid inferior
        }

        private void cmbJuegos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJuegos.SelectedItem != null)
            {
                var juego = (Juego)cmbJuegos.SelectedItem;
                int idJuego = juego.IdJuego;

                CargarGenerosAsignados(idJuego);
            }
        }

        private void FrmAsignarGenero_Load(object sender, EventArgs e)
        {

        }
    }

}
