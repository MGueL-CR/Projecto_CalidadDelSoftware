using EventosCSW.BLL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventosCSW.WEB.Pages
{
    public partial class Roles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvListaRoles.DataSource = RolBLL.SelectRoles();
            gvListaRoles.DataBind();
        }


    }
}