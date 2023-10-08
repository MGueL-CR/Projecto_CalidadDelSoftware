using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.EL.Clases
{
    public class Miembro
    {
        public int Id { set; get; }
        public string Cedula { set; get; }
        public string CodEmpleado { set; get; }
        public string NombreCompleto { set; get; }
        public string Correo { set; get; }
        public string Telefono { set; get; }
        public bool Estado { set; get; }
        public bool Asistencia { set; get; }
        public bool HoraIngreso { set; get; }
        public Mesa Mesa { set; get; }
        public Usuario Usuario { set; get; }
    }
}
