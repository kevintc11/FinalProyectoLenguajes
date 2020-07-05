using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoDatos;
using LogicaNegocio;

namespace Interfaz.ModuloCliente
{
    public partial class ClientePedidos : System.Web.UI.Page
    {
        AdministracionPedidos pedidos = new AdministracionPedidos();
        AdministracionPlatos platos = new AdministracionPlatos();
        Plato platoBuscado = new Plato();
        ListPlatoInfo listaPlatosOriginal = new ListPlatoInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvMenu.DataSource = platos.listPlatos();
            gvMenu.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloCliente/ClienteMainMenu.aspx?usuario=" + (String)Session["temporal1"]);
        }

        protected void bt_Click(object sender, EventArgs e)
        {


            if(espaciosVacios())
            {
                platoBuscado = platos.buscarPlato(int.Parse(tbDishID.Text));
                PlatoInfo platoNuevo = new PlatoInfo(int.Parse(tbDishID.Text), int.Parse(tbCant.Text),
                    (pedidos.getLastPedidoID().PedidoID + 1), platoBuscado.Precio, platoBuscado.Nombre);

                ((ListPlatoInfo)Session["TempLista"]).addPlato(platoNuevo);
                //listaPlatosOriginal.addPlato(platoNuevo);
                ((ListPlatoInfo)Session["TempLista"]).eliminarPlato();

                gvCarrito.DataSource = ((ListPlatoInfo)Session["TempLista"]).GetListPlatoInfo();
                gvCarrito.DataBind();
                //pedidos.insertPedido("04-01-2003",1,1);
            }
        }

        public Boolean espaciosVacios()
        {
            if (tbDishID.Text == "" || tbCant.Text == "")
            {
                Type cstype = this.GetType();

                ClientScriptManager cs = Page.ClientScript;

                if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                {
                    String cstext = "alert('Debe de Llenar Correctamente Todos los Datos Requeridos');";
                    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                }
                return false;
            }
            return true;
        }
    }
}