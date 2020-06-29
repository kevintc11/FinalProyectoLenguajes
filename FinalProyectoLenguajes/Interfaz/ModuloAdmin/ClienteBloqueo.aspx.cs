using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;

namespace Interfaz
{
    public partial class ClienteBloqueo : System.Web.UI.Page
    {
        AdministracionUsuarios usuarios = new AdministracionUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvClientes.DataSource = usuarios.consultaClientes();
            gvClientes.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/MenuAdmin.aspx");
        }

        protected void btBlock_Click(object sender, EventArgs e)
        {
            if (espaciosVacios())
            {
                try
                {
                    usuarios.bloquearCliente(tbBlock.Text);

                    gvClientes.DataBind();
                   
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Usuario bloqueado correctamente');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                        gvClientes.DataBind();
                    }
                    Response.Redirect("~/ModuloAdmin/ClienteBloqueo.aspx");
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
            if (tbBlock.Text == "")
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