using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.EL.Clases
{
    public class Asistencia
    {
        public int Id { set; get; }
        public Evento Evento { set; get; }
        public Miembro Miembro { set; get; }
        public bool Confirmado { set; get; }
    }
}
