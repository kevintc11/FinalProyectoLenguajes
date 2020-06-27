using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoDatos;
using System.Collections.Generic;
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
                    Response.Redirect("~/ModuloAdmin/MenuAdmin.aspx");
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
           

           

            ////Response.Redirect("~/MenuAdmin.aspx");


            //LectArchivo lectura1 = new LectArchivo();

            //SqlConnectionStringBuilder conect = lectura1.leerServer1();
            //SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            //DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            //Usuario usuario1 = dc.Usuario.First(usua => usua.DescUsuario.Equals("NachoMan"));
            
            ////var clientes = from cliente in dc.Cliente
            ////               where cliente.indicActivoCliente == 1
            ////               select cliente;
            //TextBox2.Text = usuario1.NombreCompleto;
        }

        protected void btRegist_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registro.aspx");
        }
    }
}