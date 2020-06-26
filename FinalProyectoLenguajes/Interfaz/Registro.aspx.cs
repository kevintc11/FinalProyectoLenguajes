using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio Sesion.aspx");
        }

        protected void btRegist_Click(object sender, EventArgs e)
        {
            Regist();
        }

        public Boolean espaciosVacios()
        {
            if(txUser.Text == "" || txName.Text == "" || txMail.Text == "" || txPassd1.Text == "" || rblUserT.SelectedIndex <= -1)
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
            if(espaciosVacios() == true)
            {
                txName.Text = "Hora Si Caballero";

                switch(int.Parse(rblUserT.SelectedValue))
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                //Comprobacion de existencia y creación
            }else
            {

            }
        }
    }
}