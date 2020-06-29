using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class ClienteBuscar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dgClientes.DataBind();
        }

        AdministracionUsuarios mInterfaz = new AdministracionUsuarios();

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/UsuarioMenu.aspx");
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            if(espaciosVacios())
            {
                if(mInterfaz.comprobarUsuario(tbNick.Text))
                {
                    dgClientes.DataSource = mInterfaz.obtenerUsuarioUnicoLista(tbNick.Text);
                    dgClientes.DataBind();
                }
                else
                {
                    Type cstype = this.GetType();

                    ClientScriptManager cs = Page.ClientScript;

                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('El Usuario No Existe');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            }
        }

        public Boolean espaciosVacios()
        {
            if (tbNick.Text == "" )
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