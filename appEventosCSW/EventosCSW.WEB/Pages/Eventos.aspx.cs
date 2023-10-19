using EventosCSW.BLL.Clases;
using EventosCSW.EL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventosCSW.WEB
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarEventos();
        }

        private void CargarEventos()
        {
            gvListaEventos.DataSource = EventoBLL.SelectEventos();
            gvListaEventos.DataBind();
        }

        protected void RegresarInicio(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void CrearEvento(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/EventoForm.aspx?Id=0");
        }

        protected void EditarEvento(object sender, EventArgs e)
        {
            LinkButton lbtn= sender as LinkButton;
            Response.Redirect($"~/Pages/EventoForm.aspx?Id={lbtn.CommandArgument}");
        }

        protected void VerEvento(object sender, EventArgs e)
        {
            SoloLectura(true);

            LinkButton lbtn = sender as LinkButton;
            int vId = Convert.ToInt32(lbtn.CommandArgument);

            Evento oEvento = EventoBLL.SelectEventoByID(vId);
            txtId.Text = oEvento.Id.ToString();
            txtNombre.Text = oEvento.Nombre;
            txtFecha.Text = oEvento.Fecha.ToShortDateString();
            txtCantidad.Text = oEvento.Cantidad.ToString();
            chkEstado.Checked = oEvento.Estado;
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "ShowDetails()", true);
        }

        private void SoloLectura(bool pValor)
        {
            txtId.ReadOnly = pValor;
            txtNombre.ReadOnly = pValor;
            txtFecha.ReadOnly = pValor;
            txtCantidad.ReadOnly = pValor;
            chkEstado.Enabled = !pValor;
        }
    }
}