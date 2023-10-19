using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.BLL.Tools
{
    public class ValidadorBLL
    {
        public static void ValidarNombre(string pValor)
        {
            if (String.IsNullOrEmpty(pValor))
            {
                throw new ApplicationException("El nombre no puede estar vacio");
            }

            if (string.IsNullOrWhiteSpace(pValor))
            {
                throw new ApplicationException("El nombre no puede estar vacio");
            }
        }

        public static void ValidarCantidad(string pValor)
        {
            if (String.IsNullOrEmpty(pValor))
            {
                throw new ApplicationException("La cantidad no puede estar vacia");
            }

            if (Convert.ToInt32(pValor) <= 0)
            {
                throw new ApplicationException("La cantidad debe ser de al menos de uno o más integrantes");
            }
        }

        public static void ValidarFecha(string pValor)
        {
            if (String.IsNullOrEmpty(pValor))
            {
                throw new ApplicationException("La fecha no puede estar vacia");
            }

            if (Convert.ToDateTime(pValor) <= DateTime.Now)
            {
                throw new ApplicationException("La fecha debe ser mayor a hoy");
            }
        }
    }
}
