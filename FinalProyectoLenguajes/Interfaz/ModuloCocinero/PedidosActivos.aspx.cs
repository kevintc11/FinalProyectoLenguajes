using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;

namespace Interfaz.ModuloCocinero
{
    public partial class PedidosActivos : System.Web.UI.Page
    {
        AdministracionPedidos pedidos = new AdministracionPedidos();
        protected void Page_Load(object sender, EventArgs e)
        {
            dgPedidos.DataSource = pedidos.pedidosActivos();
            dgPedidos.DataBind();
            cambiarColores();
        }

        protected void dgPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void cambiarColores()
        {

            foreach (GridViewRow row in dgPedidos.Rows)
            {
                string valor = dgPedidos.Rows[row.RowIndex].Cells[6].Text;
                int value = int.Parse(valor);
                if (value == 1)
                {
                    dgPedidos.Rows[row.RowIndex].BackColor = Color.Green;
                }
                else if (value == 2)
                {
                    dgPedidos.Rows[row.RowIndex].BackColor = Color.Yellow;
                }
                else if (value == 3)
                {
                    dgPedidos.Rows[row.RowIndex].BackColor = Color.Red;
                }
            }
        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (espaciosVacios())
            {
                pedidos.actualizarEstadoPedido(int.Parse(tbPedidoID.Text), 5);
                dgPedidos.DataBind();
                
                Type cstype = this.GetType();

                ClientScriptManager cs = Page.ClientScript;

                if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                {
                    String cstext = "alert('El pedido fue entregado');";
                    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                }
                Response.Redirect("~/ModuloCocinero/PedidosActivos.aspx");
            }
        }

        public Boolean espaciosVacios()
        {
            if (tbPedidoID.Text == "")
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

        protected void btnDeshacer_Click(object sender, EventArgs e)
        {
            cambiarColores();
        }
    }
}