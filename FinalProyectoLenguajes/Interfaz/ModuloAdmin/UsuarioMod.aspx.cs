using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class ClienteMod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        AdministracionUsuarios mInterfaz = new AdministracionUsuarios();

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/UsuarioMenu.aspx");
        }

        protected void btMod_Click(object sender, EventArgs e)
        {

        }

        public Boolean espaciosVacios()
        {
            if (tbNick.Text == "" || tbName.Text == "" || tbMail.Text == "" || tbAddress.Text == "" ||
               tbPass.Text == "" || !mInterfaz.comprobarCorreo(tbMail.Text))
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