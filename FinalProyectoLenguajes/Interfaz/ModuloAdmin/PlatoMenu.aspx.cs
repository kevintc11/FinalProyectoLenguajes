using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btPed_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/PlatoBuscar.aspx");
        }

        protected void btModify_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/PlatoMod.aspx");
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/PlatoEliminar.aspx");
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/PlatoAgregar.aspx");
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/MenuAdmin.aspx?usuario=" + (string)Session["temporal1"]);
        }
    }
}