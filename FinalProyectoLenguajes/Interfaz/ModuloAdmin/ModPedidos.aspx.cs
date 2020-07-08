using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz.ModuloAdmin
{
    public partial class ModPedidos : System.Web.UI.Page
    {
        AdministracionPedidos pedidos = new AdministracionPedidos();
        AdministracionPlatos platos = new AdministracionPlatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = platos.Pedidos();
            lblMensaje.Text = "";
            GridView1.DataBind();
        }

        protected void btModify_Click(object sender, EventArgs e)
        {
            if (espaciosLlenos())
            {
                if (pedidos.esNumero(tbPedidoID.Text))
                {
                    if (pedidos.comprobarPedido(tbPedidoID.Text))
                    {
                        pedidos.actualizarEstadoPedido(int.Parse(tbPedidoID.Text), int.Parse(rblStatus.SelectedValue));
                        GridView1.DataSource = platos.Pedidos();
                        GridView1.DataBind();
                        lblMensaje.Text = "El pedido se actualizó correctamente";
                    }
                    else
                    {
                        lblMensaje.Text = "El pedido no existe";
                    }
                }
            }
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/MenuAdmin.aspx");
        }

        public Boolean espaciosLlenos()
        {
            if (tbPedidoID.Text == "")
            {
                lblMensaje.Text = "Debe digitar el ID del pedido a actualizar";
                return false;
            }
            return true;
        }
    }
}