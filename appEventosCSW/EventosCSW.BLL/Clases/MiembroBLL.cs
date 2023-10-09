using EventosCSW.DAL.Clases;
using EventosCSW.EL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.BLL.Clases
{
    public class MiembroBLL
    {
        public static bool CreateMiembro(Miembro pMiembro)
        {
            return MiembroDAL.CreateElement(pMiembro);
        }

        public static bool UpdateMiembro(Miembro pMiembro)
        {
            return MiembroDAL.UpdateElement(pMiembro);
        }

        public static Miembro SelectMiembroByID(int pId)
        {
            return MiembroDAL.SelectElementByID(pId);
        }

        public static Miembro SelectMiembroByCedula(string pCedula)
        {
            return MiembroDAL.SelectElementByCedula(pCedula);
        }

        public static Miembro SelectMiembroByCodigo(string pCodigo)
        {
            return MiembroDAL.SelectElementByCodigo(pCodigo);
        }

        public static List<Miembro> SelectMiembros()
        {
            return MiembroDAL.SelectElements();
        }
    }
}
