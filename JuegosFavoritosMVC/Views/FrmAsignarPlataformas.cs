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
    
    public partial class FrmAsignarPlataformas : Form
    {
        JuegoController juegoController = new JuegoController();
        PlataformaController plataformaController = new PlataformaController();
        JuegoPlataformaController controllerJP = new JuegoPlataformaController();
        public FrmAsignarPlataformas()
        {
            InitializeComponent();
            CargarCombos();
            dgvPlataformas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlataformas.MultiSelect = false;
            dgvPlataformas.ReadOnly = true;
            dgvPlataformas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void CargarCombos()
        {
            cmbJuegos.DataSource = juegoController.Listar();
            cmbJuegos.DisplayMember = "NombreDelJuego";
            cmbJuegos.ValueMember = "IdJuego";

            cmbPlataformas.DataSource = plataformaController.Listar();
            cmbPlataformas.DisplayMember = "NombrePlataforma";
            cmbPlataformas.ValueMember = "IdPlataforma";
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            int idJuego = Convert.ToInt32(cmbJuegos.SelectedValue);
            int idPlataforma = Convert.ToInt32(cmbPlataformas.SelectedValue);

            if (controllerJP.ExisteAsignacion(idJuego, idPlataforma))
            {
                MessageBox.Show("Este juego ya tiene asignada esta plataforma.");
                return;
            }

            controllerJP.Asignar(idJuego, idPlataforma, dtpFecha.Value);
            MessageBox.Show("Plataforma asignada correctamente.");
            CargarPlataformas();
        }
        void CargarPlataformas()
        {
            if (cmbJuegos.SelectedItem == null) return;

            var juego = (JuegosFavoritosMVC.Models.Juego)cmbJuegos.SelectedItem;
            int idJuego = juego.IdJuego;

            dgvPlataformas.DataSource = controllerJP.ListarPorJuego(idJuego);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvPlataformas.CurrentRow == null) return;
            int idJuego = ((JuegosFavoritosMVC.Models.Juego)cmbJuegos.SelectedItem).IdJuego;
            int idPlataforma = Convert.ToInt32(dgvPlataformas.CurrentRow.Cells["IdPlataforma"].Value);
            controllerJP.Quitar(idJuego, idPlataforma);
            MessageBox.Show("Plataforma quitada correctamente.");
            CargarPlataformas();
        }

        private void cmbJuegos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJuegos.SelectedValue != null)
            {
                CargarPlataformas();
            }
        }
    }
}
