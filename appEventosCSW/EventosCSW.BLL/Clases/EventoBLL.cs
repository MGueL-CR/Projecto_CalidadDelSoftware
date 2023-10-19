using EventosCSW.DAL.Clases;
using EventosCSW.EL.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.BLL.Clases
{
    public class EventoBLL
    {
        private static bool CreateEvento(Evento pEvento)
        {
            return EventoDAL.CreateElement(pEvento);
        }

        private static bool UpdateEvento(Evento pEvento)
        {
            return EventoDAL.UpdateElement(pEvento);
        }

        public static bool SaveEvento(Evento pEvento, DataTable pLista, int IdUsuario)
        {
            if (pEvento.Id == 0)
            {
                return CreateEvento(pEvento) && MiembroDAL.InsertListaMiembros(pLista, IdUsuario);
            }
            else
            {
                return UpdateEvento(pEvento);
            }
        }

        public static Evento SelectEventoByID(int pId)
        {
            return EventoDAL.SelectElementByID(pId);
        }

        public static List<Evento> SelectEventos()
        {
            return EventoDAL.SelectElements();
        }

        public static int ValorConsecutivo()
        {
            return SelectEventos().Count == 0? 100: SelectEventos().Max(x => x.Id) + 100;
        }
    }
}
