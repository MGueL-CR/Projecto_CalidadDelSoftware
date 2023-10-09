using EventosCSW.DAL.Clases;
using EventosCSW.EL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.BLL.Clases
{
    public class EventoBLL
    {
        public static bool CreateEvento(Evento pEvento)
        {
            return EventoDAL.CreateElement(pEvento);
        }

        public static bool UpdateEvento(Evento pEvento)
        {
            return EventoDAL.UpdateElement(pEvento);
        }

        public static Evento SelectEventoByID(int pId)
        {
            return EventoDAL.SelectElementByID(pId);
        }

        public static List<Evento> SelectEventos()
        {
            return EventoDAL.SelectElements();
        }
    }
}
