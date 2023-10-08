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
    public class EventoDAL
    {
        public static bool CreateElement(Evento pEvento)
        {
            using(SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Insert_Evento"
                };

                oCMD.Parameters.AddWithValue("@nombre", pEvento.Nombre);
                oCMD.Parameters.AddWithValue("@fecha", pEvento.Fecha);
                oCMD.Parameters.AddWithValue("@cantidad", pEvento.Cantidad);
                oCMD.Parameters.AddWithValue("@estado", pEvento.Estado);

                try
                {
                    oCX.Open();
                    oCMD.ExecuteNonQuery();
                    return true;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n{1}.\n\nDetalles del error:\n{2}",
                        "Falló al crear el nuevo evento.", pEvento.Nombre, eErr.Message));
                }
            }
        }

        public static bool UpdateElement(Evento pEvento)
        {
            using(SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Update_Evento"
                };

                oCMD.Parameters.AddWithValue("@id", pEvento.Id);
                oCMD.Parameters.AddWithValue("@nombre", pEvento.Nombre);
                oCMD.Parameters.AddWithValue("@fecha", pEvento.Fecha);
                oCMD.Parameters.AddWithValue("@cantidad", pEvento.Cantidad);
                oCMD.Parameters.AddWithValue("@estado", pEvento.Estado);

                try
                {
                    oCX.Open();
                    oCMD.ExecuteNonQuery();
                    return true;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n{1}.\n\nDetalles del error:\n{2}", 
                        "Falló al actualizar el evento:", pEvento.Nombre, eErr.Message));
                }

            }
        }

        public static Evento SelectElementByID(int pId)
        {
            Evento oElemento = new Evento();

            using(SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Evento_By_Id"
                };

                oCMD.Parameters.AddWithValue("@id", pId);

                try
                {
                    oCX.Open();

                    using(SqlDataReader oDR = oCMD.ExecuteReader())
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
                        "Falló al recuperar la información del evento.", eErr.Message));
                }
            }
        }

        public static List<Evento> SelectElements()
        {
            List<Evento> nLista = new List<Evento>();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Evento"
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
                        "Falló al recuperar la información de los eventos.", eErr.Message));
                }

            }
        }

        private static Evento ConvertToObject(SqlDataReader pDR)
        {
            return new Evento()
            {
                Id = Convert.ToInt32(pDR["id"]),
                Nombre = pDR["nombre"].ToString(),
                Fecha = Convert.ToDateTime(pDR["fecha"]),
                Cantidad = Convert.ToInt32(pDR["cantidad"]),
                Estado = Convert.ToBoolean(pDR["estado"])
            };
        }
    }
}
