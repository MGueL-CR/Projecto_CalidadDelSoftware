using EventosCSW.DAL.Clases;
using EventosCSW.EL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.BLL.Clases
{
    public class MesaBLL
    {
        public static bool UpdateMesa(Mesa pMesa)
        {
            return MesaDAL.UpdateElement(pMesa);
        }

        public static Mesa SelectMesaByID(int pId)
        {
            return MesaDAL.SelectElementByID(pId);
        }

        public static List<Mesa> SelectMesas()
        {
            return MesaDAL.SelectElements();
        }
    }
}
