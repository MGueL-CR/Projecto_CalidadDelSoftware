using EventosCSW.BLL.Clases;
using EventosCSW.BLL.Tools;
using EventosCSW.EL.Clases;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventosCSW.WEB.Pages
{
    public partial class EventoForm : System.Web.UI.Page
    {
        private static int IdEvento = 0;
        private static DataTable lstMiembros = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            if (Request.QueryString["Id"] != null)
            {
                IdEvento = Convert.ToInt32(Request.QueryString["Id"].ToString());
                if (IdEvento != 0)
                {
                    lblTitle.Text = "Editar Evento";

                    Evento oEvento = EventoBLL.SelectEventoByID(IdEvento);
                    txtId.Text = oEvento.Id.ToString();
                    txtNombre.Text = oEvento.Nombre;
                    txtFecha.Text = oEvento.Fecha.ToString("yyyy-MM-dd"); // Convert.ToDateTime(oEvento.Fecha).ToString("dd/mm/aaaa");
                    txtCantidad.Text = oEvento.Cantidad.ToString();
                    chkEstado.Checked = oEvento.Estado;
                }
                else
                {
                    lblTitle.Text = "Nuevo Evento";
                    txtId.Enabled = false;
                    txtId.Text = EventoBLL.ValorConsecutivo().ToString();
                    txtCantidad.Enabled = false;
                    chkEstado.Enabled = false;
                    chkEstado.Checked = true;
                }
            }
            else
            {
                Response.Redirect("~/Pages/Eventos.aspx");
            }
        }

        private void ValidarCampos()
        {
            ValidadorBLL.ValidarNombre(txtNombre.Text);
            ValidadorBLL.ValidarFecha(txtFecha.Text);
            ValidadorBLL.ValidarCantidad(txtCantidad.Text);
        }

        protected void GuardarEvento(object sender, EventArgs e)
        {
            bool vResult = false;

            try
            {
                ValidarCampos();

                Evento oEvento = new Evento()
                {
                    Id = IdEvento,
                    Nombre = txtNombre.Text,
                    Fecha = Convert.ToDateTime(txtFecha.Text),
                    Cantidad = Convert.ToInt32(txtCantidad.Text),
                    Estado = chkEstado.Checked
                };

                vResult = EventoBLL.SaveEvento(oEvento, lstMiembros, 1);
            }
            catch (ApplicationException aErr)
            {
                MostarMensaje(aErr.Message);
            }
            catch (Exception eErr)
            {
                MostarMensaje(eErr.Message);
                Response.Redirect("~/Pages/Eventos.aspx");
            }

            if (vResult)
            {
                MostarMensaje("Evento registrado correctamente");
                Response.Redirect("~/Pages/Eventos.aspx");
            }
            else
            {
                MostarMensaje("No se logró guardar el evento");
            }
        
        }

        private void MostarMensaje(string pMensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "Script", string.Format("alert('{0}')", pMensaje), true);
        }

        protected void LeerArchivo(object sender, EventArgs e)
        {
            string ruta_carpeta = HttpContext.Current.Server.MapPath("~/Temporal");

            if (!Directory.Exists(ruta_carpeta))
            {
                Directory.CreateDirectory(ruta_carpeta);
            }

            //GUARDAMOS EL ARCHIVO EN LOCAL
            var ruta_guardado = Path.Combine(ruta_carpeta, FileUpload1.FileName);
            FileUpload1.SaveAs(ruta_guardado);


            IWorkbook MiExcel = null;
            FileStream fs = new FileStream(ruta_guardado, FileMode.Open, FileAccess.Read);

            if (Path.GetExtension(ruta_guardado) == ".xlsx")
                MiExcel = new XSSFWorkbook(fs);
            else
                MiExcel = new HSSFWorkbook(fs);


            ISheet hoja = MiExcel.GetSheetAt(0);

            DataTable table = new DataTable();
            table.Columns.Add("Cedula", typeof(string));
            table.Columns.Add("Empleado", typeof(string));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Correo", typeof(string));
            table.Columns.Add("Telefono", typeof(string));
            table.Columns.Add("Estado", typeof(string));
            table.Columns.Add("Asistencia", typeof(string));
            table.Columns.Add("Ingreso", typeof(string));
            table.Columns.Add("Mesa", typeof(string));

            if (hoja != null)
            {

                int cantidadfilas = hoja.LastRowNum;

                for (int i = 1; i <= cantidadfilas; i++)
                {
                    IRow fila = hoja.GetRow(i);


                    if (fila != null)
                        table.Rows.Add(
                            fila.GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK).NumericCellValue.ToString() : "",
                            fila.GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                            fila.GetCell(2, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(2, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                            fila.GetCell(3, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(3, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                            fila.GetCell(4, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(4, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                            fila.GetCell(5, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(5, MissingCellPolicy.RETURN_NULL_AND_BLANK).NumericCellValue.ToString() : "",
                            fila.GetCell(6, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(6, MissingCellPolicy.RETURN_NULL_AND_BLANK).NumericCellValue.ToString() : "",
                            fila.GetCell(7, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(7, MissingCellPolicy.RETURN_NULL_AND_BLANK).DateCellValue.ToString("hh:mm", new CultureInfo("es-ES")) : "",
                            fila.GetCell(8, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(8, MissingCellPolicy.RETURN_NULL_AND_BLANK).NumericCellValue.ToString() : ""
                            );
                }
            }
            lstMiembros = table;
            gvListaMiembros.DataSource = table;
            gvListaMiembros.DataBind();
            txtCantidad.Text = gvListaMiembros.Rows.Count.ToString();
            /*
            int resultado = cargarEnSQL(table);

            if (resultado == 1)
            {
                gvListaMiembros.DataSource = table;
                gvListaMiembros.DataBind();
            }*/
        }
    }
}