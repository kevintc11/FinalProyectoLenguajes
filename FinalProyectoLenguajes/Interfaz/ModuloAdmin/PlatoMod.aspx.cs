using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoDatos;
using LogicaNegocio;

namespace Interfaz
{
    public partial class ModificarPlato : System.Web.UI.Page
    {

        AdministracionPlatos platos = new AdministracionPlatos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/PlatoMenu.aspx");
        }

        protected void btMod_Click(object sender, EventArgs e)
        {
           
            if (espaciosVacios() == true)
            {
                try
                {
                    try
                    {
                        platos.buscarPlato(int.Parse(tbPlatoID.Text));
                    }
                    catch (Exception)
                    {

                        throw new Exception("El plato no existe");
                    }
           
                    if (platos.buscarPlato(int.Parse(tbPlatoID.Text)) != null)
                    {
                        platos.modificarPlato(false, int.Parse(tbPlatoID.Text), tbDishName.Text, tbDesc.Text, int.Parse(tbPrice.Text), int.Parse(rdEstado.SelectedValue), null, 1);
                        Type cstype = this.GetType();
                        ClientScriptManager cs = Page.ClientScript;
                        if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                        {
                            String cstext = "alert('Plato modificado correctamente');";
                            cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                        }
                    }
                    else
                    {
                        Type cstype = this.GetType();
                        ClientScriptManager cs = Page.ClientScript;
                        if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                        {
                            String cstext = "alert('El plato no se encuentra');";
                            cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('" + ex.Message + "');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            }
        }

        public Boolean espaciosVacios()
        {
            if (tbDishName.Text == "" || tbDesc.Text == "" || tbPrice.Text == "" || tbPlatoID.Text == "")
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

        protected void btnComprobar_Click1(object sender, EventArgs e)
        {
            if (espaciosVacios())
            {
                if (platos.buscarPlato(int.Parse(tbPlatoID.Text)) != null)
                {

                }
            }
        }
    }
}