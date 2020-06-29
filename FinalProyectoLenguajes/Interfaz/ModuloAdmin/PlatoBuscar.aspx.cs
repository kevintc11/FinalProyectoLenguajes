using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;

namespace Interfaz
{
    public partial class BuscarPlatos : System.Web.UI.Page
    {
        AdministracionPlatos platos = new AdministracionPlatos();

        protected void Page_Load(object sender, EventArgs e)
        {
        
            dgPlato.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/PlatoMenu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            if(espaciosVacios())
            {
                int platoID = int.Parse(tbSearch.Text);
                dgPlato.DataSource = platos.buscarPlato(platoID);
                dgPlato.DataBind();
            }
        }

        public Boolean espaciosVacios()
        {
            if (tbSearch.Text == "")
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