using AccesoDatos;
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
            tbName.Enabled = false;
            tbMail.Enabled = false;
            tbAddress.Enabled = false;
            tbPass.Enabled = false;
            btMod.Enabled = false;
        }

        AdministracionUsuarios mInterfaz = new AdministracionUsuarios();

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/UsuarioMenu.aspx");
        }

        protected void btMod_Click(object sender, EventArgs e)
        {
            if(espaciosVacios())
            {
                mInterfaz.actualizarUsuario(tbNick.Text,tbMail.Text,tbName.Text,tbPass.Text,tbAddress.Text);
            }
        }

        protected void btCheck_Click(object sender, EventArgs e)
        {
            if(espaciosVaciosNick())
            {
                if (mInterfaz.comprobarUsuario(tbNick.Text))
                {
                    string value = tbNick.Text;
                    tbName.Enabled = true;
                    tbMail.Enabled = true;
                    tbAddress.Enabled = true;
                    tbPass.Enabled = true;
                    btMod.Enabled = true;

                    tbName.Text = mInterfaz.obtenerUsuario(value).NombreCompleto;
                    tbMail.Text = mInterfaz.obtenerUsuario(value).CorreoElectronico;
                    tbAddress.Text = mInterfaz.obtenerUsuario(value).Direccion;
                    tbPass.Text = mInterfaz.obtenerUsuario(value).Contraseña;
                    btCheck.Enabled = false;
                    tbNick.Enabled = false;
                }else
                {
                    Type cstype = this.GetType();

                    ClientScriptManager cs = Page.ClientScript;

                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Este Usuario No Existe');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
                
            }
        }

        public Boolean espaciosVaciosNick()
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