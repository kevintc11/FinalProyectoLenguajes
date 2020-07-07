using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
namespace Interfaz
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        AdministracionUsuarios mInterfaz = new AdministracionUsuarios();

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InicioSesion.aspx");
        }

        protected void btRegist_Click(object sender, EventArgs e)
        {
            Regist();
        }

        public Boolean espaciosVacios()
        {
            if(txUser.Text == "" || txName.Text == "" || txMail.Text == "" || txAddress.Text == "" ||
               txPassd1.Text == "" || rblUserT.SelectedIndex <= -1 || !mInterfaz.comprobarCorreo(txMail.Text))
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

        public void Regist()
        {
            int valor = 0;
            if(espaciosVacios() == true)
            {
                if(mInterfaz.comprobarUsuario(txUser.Text))
                {
                    Type cstype = this.GetType();

                    ClientScriptManager cs = Page.ClientScript;

                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Usuario Ya Existente');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
                else
                {
                    switch (int.Parse(rblUserT.SelectedValue))
                    {
                        case 1:
                            valor = 1;
                            break;
                        case 2:
                            valor = 2;
                            break;
                        case 3:
                            valor = 3;
                            break;
                    }
                    mInterfaz.insertarUsuario(txUser.Text, txMail.Text, txName.Text,
                                              txPassd1.Text, valor, txAddress.Text);

                    Type cstype = this.GetType();

                    ClientScriptManager cs = Page.ClientScript;

                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Usuario Creado Con Éxito');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            }
        }
    }
}