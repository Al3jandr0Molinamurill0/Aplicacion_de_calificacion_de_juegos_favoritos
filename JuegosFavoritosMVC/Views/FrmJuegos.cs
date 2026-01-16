using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegosFavoritosMVC.Models;
using JuegosFavoritosMVC.Controllers;

namespace JuegosFavoritosMVC.Views
{
    public partial class FrmJuegos : Form
    {
        JuegoController controller = new JuegoController();
        int idSeleccionado = 0;
        public FrmJuegos()
        {
            InitializeComponent();
            dgvJuegos.AutoGenerateColumns = true;
            CargarJuegos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Juego j = new Juego
            {
                NombreDelJuego = txtNombre.Text,
                Creador = txtCreador.Text,
                AnioLanzamiento = int.Parse(txtAnio.Text),
                Distribuidora = txtDistribuidora.Text
            };
            controller.Insertar(j);
            MessageBox.Show("Juego guardado exitosamente.");
            CargarJuegos();
        }
        void CargarJuegos()
        {
            dgvJuegos.DataSource = controller.Listar();
            dgvJuegos.AutoGenerateColumns = true;
        }

        private void dgvJuegos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvJuegos.Rows[e.RowIndex];
                idSeleccionado = int.Parse(fila.Cells["IdJuego"].Value.ToString());
                txtNombre.Text = fila.Cells["NombreDelJuego"].Value.ToString();
                txtCreador.Text = fila.Cells["Creador"].Value.ToString();
                txtAnio.Text = fila.Cells["AnioLanzamiento"].Value.ToString();
                txtDistribuidora.Text = fila.Cells["Distribuidora"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un juego para editar.");
                return;
            }
            Juego j = new Juego
            {
                IdJuego = idSeleccionado,
                NombreDelJuego = txtNombre.Text,
                Creador = txtCreador.Text,
                AnioLanzamiento = int.Parse(txtAnio.Text),
                Distribuidora = txtDistribuidora.Text
            };
            controller.Actualizar(j);
            MessageBox.Show("Juego actualizado exitosamente.");
            Limpiar();
            CargarJuegos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un juego para eliminar.");
                return;
            }
            DialogResult r = MessageBox.Show(
                "¿Está seguro de eliminar el juego seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                controller.Eliminar(idSeleccionado);
                MessageBox.Show("Juego eliminado exitosamente.");
                Limpiar();
                CargarJuegos();
            }

        }
        void Limpiar()
        {
            idSeleccionado = 0;
            txtNombre.Clear();
            txtCreador.Clear();
            txtAnio.Clear();
            txtDistribuidora.Clear();
        }
    }
}
