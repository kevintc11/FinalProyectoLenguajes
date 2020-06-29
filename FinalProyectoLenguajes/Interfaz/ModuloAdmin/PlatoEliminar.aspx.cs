using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;

namespace Interfaz
{
    public partial class EliminarPlato : System.Web.UI.Page
    {

        AdministracionPlatos platos = new AdministracionPlatos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/PlatoMenu.aspx");

        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            if(espaciosVacios())
            {
                try
                {
                    int platoID = int.Parse(tbDelete.Text);
                    platos.eliminarPlato(platoID);
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Plato eliminado correctamente');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
                catch (Exception)
                {
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Plato no existe');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            }
        }

        public Boolean espaciosVacios()
        {
            if (tbDelete.Text == "")
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