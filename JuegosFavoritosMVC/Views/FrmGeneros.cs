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
    public partial class FrmGeneros : Form
    {
        GeneroController controller = new GeneroController();
        int idSeleccionado = 0;

        public FrmGeneros()
        {
            InitializeComponent();
            CargarGeneros();
        }

        void CargarGeneros()
        {
            try
            {
                dgvGeneros.DataSource = controller.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Genero g = new Genero
                {
                    NombreGenero = txtNombreGenero.Text,
                    Descripcion = txtDescripcion.Text
                };

                controller.Insertar(g);
                MessageBox.Show("Género guardado correctamente");

                Limpiar();
                CargarGeneros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dgvGeneros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un género");
                return;
            }

            controller.Eliminar(idSeleccionado);
            MessageBox.Show("Género eliminado");
            Limpiar();
            CargarGeneros();
        }

        void Limpiar()
        {
            txtNombreGenero.Clear();
            txtDescripcion.Clear();
            idSeleccionado = 0;
        }

        private void dgvGeneros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(dgvGeneros.Rows[e.RowIndex].Cells["IdGenero"].Value);
                txtNombreGenero.Text = dgvGeneros.Rows[e.RowIndex].Cells["NombreGenero"].Value.ToString();
                txtDescripcion.Text = dgvGeneros.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un género para editar");
                return;
            }
            if (txtNombreGenero.Text.Trim() == "")
            {
                MessageBox.Show("El nombre del género del juego es obligatorio");
                return;
            }
            Genero g = new Genero
            {
                IdGenero = idSeleccionado,
                NombreGenero = txtNombreGenero.Text,
                Descripcion = txtDescripcion.Text
            };
            controller.Actualizar(g);
            MessageBox.Show("Género actualizado");
            Limpiar();
            CargarGeneros();
        }
    }
}