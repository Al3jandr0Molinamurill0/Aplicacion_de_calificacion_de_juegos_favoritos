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
using JuegosFavoritosMVC.Models;

namespace JuegosFavoritosMVC.Views
{
    public partial class FrmPlataformas : Form
    {
        PlataformaController controller = new PlataformaController();
        int idSeleccionado = 0;
        public FrmPlataformas()
        {
            InitializeComponent();
            Cargar();
        }
        void Cargar()
        {
            dgvPlataformas.DataSource = controller.Listar();
        }
        void Limpiar()
        {
            txtNombrePlataforma.Clear();
            txtFabricante.Clear();
            idSeleccionado = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombrePlataforma.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre de la plataforma.");
                return;
            }
            Plataforma p = new Plataforma
            {
                IdPlataforma = idSeleccionado,
                NombrePlataforma = txtNombrePlataforma.Text,
                Fabricante = txtFabricante.Text
            };
            if (idSeleccionado == 0)
                controller.Insertar(p);
            else
                controller.Editar(p);
            MessageBox.Show("Datos guardados correctamente.");
            Limpiar();
            Cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione una plataforma para eliminar.");
                return;
            }
            controller.Eliminar(idSeleccionado);
            MessageBox.Show("Plataforma eliminada correctamente.");
            Limpiar();
            Cargar();
        }

        private void dgvPlataformas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvPlataformas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(
                    dgvPlataformas.Rows[e.RowIndex].Cells["IdPlataforma"].Value);

                txtNombrePlataforma.Text =
                    dgvPlataformas.Rows[e.RowIndex].Cells["NombrePlataforma"].Value.ToString();

                txtFabricante.Text =
                    dgvPlataformas.Rows[e.RowIndex].Cells["Fabricante"].Value.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
