using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string nick;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {

        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InicioSesion.aspx");
        }

        protected void btDishes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/PlatoMenu.aspx");
        }

        protected void btUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/UsuarioMenu.aspx");
        }

        protected void btClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/ClienteBloqueo.aspx");
        }

        protected void btPed_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/Pedidos.aspx");
        }

        protected void btModPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/ModPedidos.aspx");
        }

        protected void btModEstados_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/ModEstados.aspx");
        }
    }
}