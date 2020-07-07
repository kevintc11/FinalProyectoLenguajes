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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btModify_Click(object sender, EventArgs e)
        {
            if(espaciosLlenos())
            {
                if(pedidos.esNumero(tbPedidoID.Text))
                {

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