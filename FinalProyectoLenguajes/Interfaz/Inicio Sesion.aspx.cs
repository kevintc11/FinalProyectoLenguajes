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

        string dato = "true";
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["temporal1"] = null;
            Session["hilo"] = null;
        }

        AdministracionUsuarios interfaz = new AdministracionUsuarios();

        protected void btSign_Click(object sender, EventArgs e)
        {
            try
            {
                String userData;
                if (interfaz.iniciarSesion(txNick.Text, txPass.Text))
                {
                    if(interfaz.tipoUsuario(txNick.Text) == 1)
                    {
                        userData = "~/ModuloAdmin/MenuAdmin.aspx?usuario=" + txNick.Text;
                        Response.Redirect(userData);
                    }
                    else if(interfaz.tipoUsuario(txNick.Text) == 2)
                    {
                        Session["hilo"] = dato;
                        userData = "~/ModuloCocinero/PedidosActivos.aspx?usuario=" + txNick.Text;
                        Response.Redirect(userData);
                    }
                    else if(interfaz.tipoUsuario(txNick.Text) == 3) 
                    {
                        userData = "~/ModuloCliente/ClienteMainMenu.aspx?usuario=" + txNick.Text;
                        Response.Redirect(userData);
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