using AccesoDatos;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class ClienteMainMenu : System.Web.UI.Page
    {
        string nick;
        
        AdministracionUsuarios mInterfaz = new AdministracionUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            //nick = (string)Session["temporal1"];
        }

        protected void btMod_Click(object sender, EventArgs e)
        {
            if (espaciosVacios())
            {
                nick = (string)Session["temporal1"];
                try
                {
                    mInterfaz.actualizarUsuario(nick, tbMail.Text, tbName.Text,
                                                tbPass.Text, tbAddress.Text);
                    Type cstype1 = this.GetType();

                    ClientScriptManager cs1 = Page.ClientScript;

                    if (!cs1.IsStartupScriptRegistered(cstype1, "PopupScript"))
                    {
                        String cstext = "alert('Se Han Efectuado Los Cambios');";
                        cs1.RegisterStartupScript(cstype1, "PopupScript", cstext, true);
                    }
                    Response.Redirect("~/ModuloCliente/ClienteMainMenu.aspx?");
                }
                catch (Exception ex)
                {
                    Type cstype = this.GetType();

                    ClientScriptManager cs = Page.ClientScript;

                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('" + ex.Message + "');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            }
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloCliente/ClienteMainMenu.aspx?");
        }

        public Boolean espaciosVacios()
        {
            if (tbName.Text == ""|| tbPass.Text == ""|| tbMail.Text == "" || tbAddress.Text == "")
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