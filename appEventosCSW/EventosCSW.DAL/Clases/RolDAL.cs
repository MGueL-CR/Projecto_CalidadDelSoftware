using EventosCSW.DAL.Tools;
using EventosCSW.EL.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.DAL.Clases
{
    public class RolDAL
    {
        public static Rol SelectElementByID(int pId)
        {
            Rol oElemento = new Rol();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Rol_By_Id"
                };

                oCMD.Parameters.AddWithValue("@id", pId);

                try
                {
                    oCX.Open();

                    using (SqlDataReader oDR = oCMD.ExecuteReader())
                    {
                        while (oDR.Read())
                        {
                            oElemento = ConvertToObject(oDR);
                        }
                    }

                    return oElemento;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n\nDetalles del error:\n{1}",
                        "Falló al recuperar la información del Rol.", eErr.Message));
                }
            }
        }

        public static List<Rol> SelectElements()
        {
            List<Rol> nLista = new List<Rol>();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Rol"
                };

                try
                {
                    oCX.Open();

                    using (SqlDataReader oDR = oCMD.ExecuteReader())
                    {
                        while (oDR.Read())
                        {
                            nLista.Add(ConvertToObject(oDR));
                        }
                    }

                    return nLista;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n\nDetalles del error:\n{1}",
                        "Falló al recuperar la información de los roles.", eErr.Message));
                }

            }
        }

        private static Rol ConvertToObject(SqlDataReader pDR)
        {
            return new Rol()
            {
                Id = Convert.ToInt32(pDR["id"]),
                Tipo = pDR["tipo"].ToString(),
                Estado = Convert.ToBoolean(pDR["estado"])
            };
        }
    }
}
