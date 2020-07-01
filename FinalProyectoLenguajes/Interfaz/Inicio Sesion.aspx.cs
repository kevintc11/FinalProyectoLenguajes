using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoDatos;
using System.Data;
using System.Data.SqlTypes;
using LogicaNegocio;

namespace Interfaz
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        AdministracionUsuarios interfaz = new AdministracionUsuarios();

        protected void btSign_Click(object sender, EventArgs e)
        {
            try
            {
                if (interfaz.iniciarSesion(txNick.Text, txPass.Text))
                {
                    if(interfaz.tipoUsuario(txNick.Text) == 1)
                    {
                        Response.Redirect("~/ModuloAdmin/MenuAdmin.aspx");
                    }
                    else if(interfaz.tipoUsuario(txNick.Text) == 2)
                    {
                        Response.Redirect("~/ModuloCocinero/PedidosActivos.aspx");
                    }
                    else if(interfaz.tipoUsuario(txNick.Text) == 3) 
                    {
                        Response.Redirect("~/ModuloCliente/ClienteMainMenu.aspx");
                    }
                }
                else
                {
                    Type cstype = this.GetType();

                    ClientScriptManager cs = Page.ClientScript;

                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Usuario O Contraseña Incorrecto');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            } 
            catch (Exception x)
            {
                String aviso = x.Message;

                Type cstype = this.GetType();

                ClientScriptManager cs = Page.ClientScript;

                if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                {
                    String cstext = "alert('"+ aviso +"');";
                    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                }
            }
        }

        protected void btRegist_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registro.aspx");
        }
    }
}