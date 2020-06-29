using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;

namespace Interfaz
{
    public partial class UsuarioEliminar : System.Web.UI.Page
    {

        AdministracionUsuarios usuarios = new AdministracionUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/UsuarioMenu.aspx");
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            if(espaciosVacios())
            {
                try
                {
                    usuarios.eliminarCliente(tbNick.Text);
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Usuario eliminado correctamente');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
                catch (Exception)
                {
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Usuario no existe');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
                
            }
        }


        public Boolean espaciosVacios()
        {
            if (tbNick.Text == "")
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