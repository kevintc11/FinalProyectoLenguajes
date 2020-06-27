using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class UsuarioMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btPed_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/UsuarioAgregar.aspx");
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/UsuarioBuscar.aspx");

        }

        protected void btMod_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/UsuarioMod.aspx");

        }

        protected void btDel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/UsuarioEliminar.aspx");

        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/MenuAdmin.aspx");
        }
    }
}