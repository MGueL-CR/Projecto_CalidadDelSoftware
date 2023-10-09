using EventosCSW.DAL.Clases;
using EventosCSW.EL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.BLL.Clases
{
    public class RolBLL
    {

        public static Rol SelectRolByID(int pId)
        {
            return RolDAL.SelectElementByID(pId);
        }

        public static List<Rol> SelectRoles()
        {
            return RolDAL.SelectElements();
        }
    }
}
