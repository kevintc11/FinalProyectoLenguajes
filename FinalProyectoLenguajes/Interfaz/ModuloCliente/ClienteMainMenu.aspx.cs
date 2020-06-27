using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz.ModuloCliente
{
    public partial class ClienteDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio Sesion.aspx");
        }

        protected void btPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloCliente/ClientePedidos.aspx");
        }

        protected void btModInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloCliente/ClienteDatos.aspx");
        }
    }
}