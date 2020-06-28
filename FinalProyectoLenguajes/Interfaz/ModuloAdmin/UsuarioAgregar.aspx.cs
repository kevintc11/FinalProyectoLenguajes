using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        AdministracionUsuarios mInterfaz = new AdministracionUsuarios();

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/UsuarioMenu.aspx");
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            newUser();
        }

        public void newUser()
        {
            int valor = 0;
            if (espaciosVacios() == true)
            {
                if (mInterfaz.comprobarUsuario(tbNick.Text))
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
                    }
                    mInterfaz.insertarUsuario(tbNick.Text, tbMail.Text, tbName.Text,
                                              tbPass.Text, valor, tbAddress.Text);

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

        public Boolean espaciosVacios()
        {
            if (tbNick.Text == "" || tbName.Text == "" || tbMail.Text == "" || tbAddress.Text == "" ||
               tbPass.Text == "" || rblUserT.SelectedIndex <= -1 || !mInterfaz.comprobarCorreo(tbMail.Text))
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