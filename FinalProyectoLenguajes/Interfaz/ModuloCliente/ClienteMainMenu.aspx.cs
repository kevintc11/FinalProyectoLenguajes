using AccesoDatos;
using LogicaNegocio;
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

        AdministracionUsuarios users = new AdministracionUsuarios();

        String nick;
        Usuario user = new Usuario();
        ListPlatoInfo listPlatoInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            listPlatoInfo = new ListPlatoInfo();
            nick = Request.QueryString["usuario"];
            Session["temporal1"] = nick;
            Session["TempLista"] = null;
            user = users.obtenerUsuario(nick);
            this.lbName.Text = user.DescUsuario;
        }
        

        protected void btSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio Sesion.aspx");
        }

        protected void btPedidos_Click(object sender, EventArgs e)
        {
            Session["TempLista"] = listPlatoInfo;
            Response.Redirect("~/ModuloCliente/ClientePedidos.aspx");
        }

        protected void btModInfo_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/ModuloCliente/ClienteDatos.aspx");
        }
    }
}