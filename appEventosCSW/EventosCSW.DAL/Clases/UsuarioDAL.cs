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
    public class UsuarioDAL
    {
        public static bool CreateElement(Usuario pUsuario)
        {
            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Insert_Evento"
                };

                oCMD.Parameters.AddWithValue("@nombreCompleto", pUsuario.NombreCompleto);
                oCMD.Parameters.AddWithValue("@correo", pUsuario.Correo);
                oCMD.Parameters.AddWithValue("@codUsuario", pUsuario.CodUsuario);
                oCMD.Parameters.AddWithValue("@contrasenia", pUsuario.Contrasenia);
                oCMD.Parameters.AddWithValue("@idRol", pUsuario.Rol.Id);
                oCMD.Parameters.AddWithValue("@estado", pUsuario.Estado);

                try
                {
                    oCX.Open();
                    oCMD.ExecuteNonQuery();
                    return true;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n{1}.\n\nDetalles del error:\n{2}", 
                        "Falló al crear el nuevo usuario.", pUsuario.NombreCompleto, eErr.Message));
                }
            }
        }

        public static bool UpdateElement(Usuario pUsuario)
        {
            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Update_Usuario"
                };

                oCMD.Parameters.AddWithValue("@id", pUsuario.Id);
                oCMD.Parameters.AddWithValue("@nombreCompleto", pUsuario.NombreCompleto);
                oCMD.Parameters.AddWithValue("@correo", pUsuario.Correo);
                oCMD.Parameters.AddWithValue("@codUsuario", pUsuario.CodUsuario);
                oCMD.Parameters.AddWithValue("@contrasenia", pUsuario.Contrasenia);
                oCMD.Parameters.AddWithValue("@idRol", pUsuario.Rol.Id);
                oCMD.Parameters.AddWithValue("@estado", pUsuario.Estado);

                try
                {
                    oCX.Open();
                    oCMD.ExecuteNonQuery();
                    return true;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n{1}.\n\nDetalles del error:\n{2}", 
                        "Falló al actualizar al usuario:", pUsuario.NombreCompleto, eErr.Message));
                }

            }
        }

        public static Usuario SelectElementByID(int pId)
        {
            Usuario oElemento = new Usuario();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Usuario_By_Id"
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
                        "Falló al recuperar la información del usuario.", eErr.Message));
                }
            }
        }

        public static List<Usuario> SelectElements()
        {
            List<Usuario> nLista = new List<Usuario>();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Usuario"
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
                        "Falló al recuperar la información de los usuarios.", eErr.Message));
                }

            }
        }

        public static Usuario UserLogin(string pCodUsuario, string pContrasenia)
        {
            Usuario oElemento = new Usuario();

            using (SqlConnection oCX = new SqlConnection(DBConnection.urlSQLServer))
            {
                SqlCommand oCMD = new SqlCommand()
                {
                    Connection = oCX,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SP_Select_Usuario_Login"
                };

                oCMD.Parameters.AddWithValue("@codUsuario", pCodUsuario);
                oCMD.Parameters.AddWithValue("@contrasenia", pContrasenia);

                try
                {
                    oCX.Open();

                    using (SqlDataReader oDR = oCMD.ExecuteReader())
                    {
                        while (oDR.Read())
                        {
                            oElemento = ConvertToObject(oDR); // No debe recibir valor para la contraseña.
                        }
                    }

                    return oElemento;
                }
                catch (Exception eErr)
                {
                    throw new ApplicationException(string.Format("{0}\n\nDetalles del error:\n{1}",
                        "Falló al recuperar la información del usuario.", eErr.Message));
                }
            }
        }

        private static Usuario ConvertToObject(SqlDataReader pDR)
        {
            return new Usuario()
            {
                Id = Convert.ToInt32(pDR["id"]),
                NombreCompleto = pDR["nombreCompleto"].ToString(),
                Correo = pDR["correo"].ToString(),
                CodUsuario = pDR["codUsuario"].ToString(),
                Contrasenia = pDR["contrasenia"].ToString(),
                Rol = RolDAL.SelectElementByID(Convert.ToInt32(pDR["idRol"])), // Instanciar Clase
                Estado = Convert.ToBoolean(pDR["estado"])
            };
        }

    }
}
