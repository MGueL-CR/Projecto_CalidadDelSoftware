using EventosCSW.DAL.Clases;
using EventosCSW.EL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.BLL.Clases
{
    public class UsuarioBLL
    {
        public static bool CreateUsuario(Usuario pUsuario)
        {
            return UsuarioDAL.CreateElement(pUsuario);
        }

        public static bool UpdateUsuario(Usuario pUsuario)
        {
            return UsuarioDAL.UpdateElement(pUsuario);
        }

        public static Usuario SelectUsuarioByID(int pId)
        {
            return UsuarioDAL.SelectElementByID(pId);
        }

        public static List<Usuario> SelectUsuarios()
        {
            return UsuarioDAL.SelectElements();
        }

        public static Usuario UserLogin(string pCodUsuario, string pContrasenia)
        {
            return UsuarioDAL.UserLogin(pCodUsuario, pContrasenia);
        }
    }
}
