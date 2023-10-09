using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.EL.Clases
{
    public class Usuario
    {
        public int Id { set; get; }
        public string NombreCompleto { set; get; }
        public string Correo { set; get; }
        public string CodUsuario { set; get; }
        public string Contrasenia { set; get; }
        public Rol Rol { set; get; }
        public bool Estado { set; get; }
    }
}
