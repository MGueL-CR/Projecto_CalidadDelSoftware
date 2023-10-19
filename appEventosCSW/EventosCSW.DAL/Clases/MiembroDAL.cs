using EventosCSW.DAL.Tools;
using EventosCSW.EL.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.DAL.Clases
{
    public class MiembroDAL
    {
        public static bool CreateElement(Miembro pMiembro)
        {
            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Insert_Miembro"
                };

                oCMD.Parameters.AddWithValue("@cedula", pMiembro.Cedula);
                oCMD.Parameters.AddWithValue("@codEmpleado", pMiembro.CodEmpleado);
                oCMD.Parameters.AddWithValue("@NombreCompleto", pMiembro.NombreCompleto);
                oCMD.Parameters.AddWithValue("@correo", pMiembro.Correo);
                oCMD.Parameters.AddWithValue("@telefono", pMiembro.Telefono);
                oCMD.Parameters.AddWithValue("@estado", pMiembro.Estado);
                oCMD.Parameters.AddWithValue("@asistencia", pMiembro.Asistencia);
                oCMD.Parameters.AddWithValue("@horaIngreso", pMiembro.HoraIngreso);
                oCMD.Parameters.AddWithValue("@idMesa", pMiembro.Mesa.Id);
                oCMD.Parameters.AddWithValue("@usModificador", pMiembro.Usuario.Id);

                try
                {
                    oCX.Open();
                    oCMD.ExecuteNonQuery();
                    return true;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n{1}.\n\nDetalles del error:\n{2}", 
                        "Falló al crear el nuevo Miembro:", pMiembro.NombreCompleto, eErr.Message));
                }
            }
        }

        public static bool InsertListaMiembros(DataTable pLstMiembros, int pIDUsuario)
        {
            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Insert_Lista_Miembros"
                };

                oCMD.Parameters.AddWithValue("@EstructuraCarga", SqlDbType.Structured).Value= pLstMiembros;
                oCMD.Parameters.AddWithValue("usModificador", pIDUsuario);

                try
                {
                    oCX.Open();
                    oCMD.ExecuteNonQuery();
                    return true;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}.\n\nDetalles del error:\n{1}",
                        "Falló al registrar los miembros", eErr.Message));
                }
            }
        }

        public static bool UpdateElement(Miembro pMiembro)
        {
            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Update_Miembro"
                };

                oCMD.Parameters.AddWithValue("@Id", pMiembro.Id);
                oCMD.Parameters.AddWithValue("@cedula", pMiembro.Cedula);
                oCMD.Parameters.AddWithValue("@codEmpleado", pMiembro.CodEmpleado);
                oCMD.Parameters.AddWithValue("@NombreCompleto", pMiembro.NombreCompleto);
                oCMD.Parameters.AddWithValue("@correo", pMiembro.Correo);
                oCMD.Parameters.AddWithValue("@telefono", pMiembro.Telefono);
                oCMD.Parameters.AddWithValue("@estado", pMiembro.Estado);
                oCMD.Parameters.AddWithValue("@asistencia", pMiembro.Asistencia);
                oCMD.Parameters.AddWithValue("@horaIngreso", pMiembro.HoraIngreso);
                oCMD.Parameters.AddWithValue("@idMesa", pMiembro.Mesa.Id);
                oCMD.Parameters.AddWithValue("@usModificador", pMiembro.Usuario.Id);

                try
                {
                    oCX.Open();
                    oCMD.ExecuteNonQuery();
                    return true;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n{1}.\n\nDetalles del error:\n{2}", 
                        "Falló al actualizar el miembro:", pMiembro.NombreCompleto, eErr.Message));
                }
            }
        }

        public static Miembro SelectElementByID(int pId)
        {
            Miembro oElemento = new Miembro();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Miembro_By_Id"
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
                        "Falló al recuperar la información del miembro:", eErr.Message));
                }
            }
        }

        public static Miembro SelectElementByCodigo(string pCodigo)
        {
            Miembro oElemento = new Miembro();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Miembro_By_CodEmpleado"
                };

                oCMD.Parameters.AddWithValue("@codEmpleado", pCodigo);

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
                        "Falló al recuperar la información del miembro:", eErr.Message));
                }
            }
        }

        public static Miembro SelectElementByCedula(string pCedula)
        {
            Miembro oElemento = new Miembro();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Miembro_By_Cedula"
                };

                oCMD.Parameters.AddWithValue("@cedula", pCedula);

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
                        "Falló al recuperar la información del miembro:", eErr.Message));
                }
            }
        }

        public static List<Miembro> SelectElements()
        {
            List<Miembro> nLista = new List<Miembro>();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Miembro"
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
                        "Falló al recuperar la información de los miembros.", eErr.Message));
                }

            }
        }

        private static Miembro ConvertToObject(SqlDataReader pDR)
        {
            return new Miembro()
            {
                Id = Convert.ToInt32(pDR["id"]),
                Cedula = pDR["cedula"].ToString(),
                CodEmpleado = pDR["codEmpleado"].ToString(),
                NombreCompleto = pDR["NombreCompleto"].ToString(),
                Correo = pDR["correo"].ToString(),
                Telefono = pDR["telefono"].ToString(),
                HoraIngreso = Convert.ToDateTime(pDR["horaIngreso"]),
                Mesa = MesaDAL.SelectElementByID(Convert.ToInt32(pDR["idMesa"])),
                Estado = Convert.ToBoolean(pDR["estado"]),
                Asistencia = Convert.ToBoolean(pDR["asistencia"]),
                Usuario = UsuarioDAL.SelectElementByID(Convert.ToInt32(pDR["usModificador"]))
            };
        }
    }
}
