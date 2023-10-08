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
    public class AsistenciaDAL
    {
        public static bool CreateElement(Asistencia pAsistencia)
        {
            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Insert_Asistencia"
                };

                oCMD.Parameters.AddWithValue("@idEvento", pAsistencia.Evento);
                oCMD.Parameters.AddWithValue("@idMiembro", pAsistencia.Miembro);
                oCMD.Parameters.AddWithValue("@confirmado", pAsistencia.Confirmado);

                try
                {
                    oCX.Open();
                    oCMD.ExecuteNonQuery();
                    return true;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n\nDetalles del error:\n{1}", 
                        "Falló al crear la nueva asistencia.", eErr.Message));
                }
            }
        }

        public static bool UpdateElement(Asistencia pAsistencia)
        {
            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Update_Asistencia"
                };

                oCMD.Parameters.AddWithValue("@id", pAsistencia.Id);
                oCMD.Parameters.AddWithValue("@idEvento", pAsistencia.Evento);
                oCMD.Parameters.AddWithValue("@idMiembro", pAsistencia.Miembro);
                oCMD.Parameters.AddWithValue("@confirmado", pAsistencia.Confirmado);

                try
                {
                    oCX.Open();
                    oCMD.ExecuteNonQuery();
                    return true;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n{2}\n\nDetalles del error:\n{1}", 
                        "Falló al actualizar la asistencia:", eErr.Message, pAsistencia.Miembro.NombreCompleto));
                }

            }
        }

        public static Asistencia SelectElementByID(int pId)
        {
            Asistencia oElemento = new Asistencia();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Asistencia_By_Id"
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
                        "Falló al recuperar la información de la asistencia.", eErr.Message));
                }
            }
        }

        public static List<Asistencia> SelectElements()
        {
            List<Asistencia> nLista = new List<Asistencia>();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Asistencia"
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
                        "Falló al recuperar la información de las asistencias.", eErr.Message));
                }

            }
        }

        private static Asistencia ConvertToObject(SqlDataReader pDR)
        {
            return new Asistencia()
            {
                Id = Convert.ToInt32(pDR["id"]),
                Evento = EventoDAL.SelectElementByID(Convert.ToInt32(pDR["idEvento"])),
                Miembro = MiembroDAL.SelectElemenByID(Convert.ToInt32(pDR["idMiembro"])),
                Confirmado = Convert.ToBoolean(pDR["estado"])
            };
        }
    }
}
