using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.EL.Clases
{
    public class Evento
    {
        public int Id { set; get; }
        public String Nombre { set; get; }
        public DateTime Fecha { set; get; }
        public int Cantidad { set; get; }
        public bool Estado { set; get; }
    }
}
