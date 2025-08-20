using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Capacitacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public string Ponente { get; set; }
        public DateTime FechaHora { get; set; }
        public int Cupo { get; set; }
        public bool InscripcionAbierta { get; set; }
        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
