using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.EL.Clases
{
    public class Mesa
    {
        public int Id { set; get; }
        public string NumMesa { set; get; }
        public int Cantidad { set; get; }
        public int Disponible { set; get; }
        public bool Estado { set; get; }
    }
}
