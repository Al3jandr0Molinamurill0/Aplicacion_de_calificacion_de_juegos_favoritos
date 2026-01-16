using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosFavoritosMVC.Models
{
    public class Juego
    {
        public int IdJuego { get; set; }
        public string NombreDelJuego { get; set; }
        public string Creador { get; set; }
        public int AnioLanzamiento { get; set; }
        public string Distribuidora { get; set; }
        public DateTime FechaRegistro { get; set; }
      
    }
}