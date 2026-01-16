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
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void administrarJuegosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmJuegos frm = new FrmJuegos();
            frm.ShowDialog();
        }

        private void génerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGeneros frm = new FrmGeneros();
            frm.ShowDialog();
        }

        private void plataformasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAsignarPlataformas frm = new FrmAsignarPlataformas();
            frm.ShowDialog();
        }

        private void géneroPorJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAsignarGenero frm = new FrmAsignarGenero();
            frm.ShowDialog();
        }

        private void plataformasPorJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void calificacionDelJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCalificacion frm = new FrmCalificacion();
            frm.ShowDialog();
        }
    }
}
