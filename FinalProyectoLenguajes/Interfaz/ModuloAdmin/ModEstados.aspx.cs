using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz.ModuloAdmin
{
    public partial class ModEstados : System.Web.UI.Page
    {
        AdministracionPedidos pedidos = new AdministracionPedidos();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvEstados.DataSource = pedidos.getEstadoPedidos();
            gvEstados.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/MenuAdmin.aspx");
        }

        protected void btModify_Click(object sender, EventArgs e)
        {
            if(espaciosLlenos())
            {
                if(pedidos.esNumero(tbTime.Text) && pedidos.esNumero(tbID.Text))
                {
                    pedidos.cambiarTiempoPedido(int.Parse(tbID.Text), int.Parse(tbTime.Text));
                    gvEstados.DataSource = pedidos.getEstadoPedidos();
                    gvEstados.DataBind();
                    Type cstype = this.GetType();

                    ClientScriptManager cs = Page.ClientScript;

                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Pedido actualizado correctamente');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
                else
                {
                    Type cstype = this.GetType();

                    ClientScriptManager cs = Page.ClientScript;

                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Valores Invalidos');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            }
        }

        public Boolean espaciosLlenos()
        {
            if (tbID.Text == "" || tbTime.Text == "")
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