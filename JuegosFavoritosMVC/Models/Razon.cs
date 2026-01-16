using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosFavoritosMVC.Models
{
    public class Razon
    {
        public int IdRazon { get; set; }
        public int IdJuego { get; set; }
        public string TextoRazon { get; set; }
        public int Calificacion { get; set; }
        public DateTime FechaOpinion { get; set; }
    }
}
