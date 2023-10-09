using EventosCSW.DAL.Clases;
using EventosCSW.EL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.BLL.Clases
{
    public class AsistenciaBLL
    {
        public static bool CreateAsistencia(Asistencia pAsistencia)
        {
            return AsistenciaDAL.CreateElement(pAsistencia);
        }

        public static bool UpdateAsistencia(Asistencia pAsistencia)
        {
            return AsistenciaDAL.UpdateElement(pAsistencia);
        }

        public static Asistencia SelectAsistenciaByID(int pId)
        {
            return AsistenciaDAL.SelectElementByID(pId);
        }

        public static List<Asistencia> SelectAsistencias()
        {
            return AsistenciaDAL.SelectElements();
        }
    }
}
