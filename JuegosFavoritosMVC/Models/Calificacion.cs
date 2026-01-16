using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosFavoritosMVC.Models
{
    public class Calificacion
    {
        public int IdJuego { get; set; }
        public int CalificacionJuego { get; set; }
        public string Razon { get; set; }
        public DateTime FechaOpinion { get; set; }
    }
}
