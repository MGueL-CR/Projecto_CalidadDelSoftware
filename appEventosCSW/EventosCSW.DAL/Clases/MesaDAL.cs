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
    public class MesaDAL
    {
        public static bool UpdateElement(Mesa pMesa)
        {
            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Update_Mesa"
                };

                oCMD.Parameters.AddWithValue("@id", pMesa.Id);
                oCMD.Parameters.AddWithValue("@numMesa", pMesa.NumMesa);
                oCMD.Parameters.AddWithValue("@cantidad", pMesa.Cantidad);
                oCMD.Parameters.AddWithValue("@disponible", pMesa.Disponible);
                oCMD.Parameters.AddWithValue("@estado", pMesa.Estado);

                try
                {
                    oCX.Open();
                    oCMD.ExecuteNonQuery();
                    return true;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n{2}\n\nDetalles del error:\n{1}",
                        "Falló al actualizar la mesa:", eErr.Message, pMesa.NumMesa));
                }

            }
        }

        public static Mesa SelectElementByID(int pId)
        {
            Mesa oElemento = new Mesa();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Mesa_By_Id"
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
                        "Falló al recuperar la información de la Mesa.", eErr.Message));
                }
            }
        }

        public static List<Mesa> SelectElements()
        {
            List<Mesa> nLista = new List<Mesa>();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Mesa"
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
                        "Falló al recuperar la información de las mesas.", eErr.Message));
                }

            }
        }

        private static Mesa ConvertToObject(SqlDataReader pDR)
        {
            return new Mesa()
            {
                Id = Convert.ToInt32(pDR["id"]),
                NumMesa = pDR["numMesa"].ToString(),
                Cantidad = Convert.ToInt32(pDR["cantidad"]),
                Disponible = Convert.ToInt32(pDR["disponible"]),
                Estado = Convert.ToBoolean(pDR["estado"])
            };
        }
    }
}
