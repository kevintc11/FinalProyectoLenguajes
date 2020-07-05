using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class ClienteMenu : System.Web.UI.Page
    {
        AdministracionPlatos platos = new AdministracionPlatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvMenu.DataSource = platos.listaPlatos();
            gvMenu.DataBind();
        }

        protected void tbOpen_Click(object sender, EventArgs e)
        {
            if (espaciosLlenos2())
            {
                if (platos.esNumero(tbId.Text))
                {
                    if (platos.buscarPlato(int.Parse(tbId.Text)) != null)
                    {
                        Type cstype = this.GetType();

                        ClientScriptManager cs = Page.ClientScript;

                        if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                        {
                            String cstext = "alert('Exito');";
                            cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                        }
                    }
                    else
                    {
                        Type cstype = this.GetType();

                        ClientScriptManager cs = Page.ClientScript;

                        if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                        {
                            String cstext = "alert('Este Plato No Existe');";
                            cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                        }
                    }
                }
                else
                {
                    Type cstype = this.GetType();

                    ClientScriptManager cs = Page.ClientScript;

                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Valor Invalido');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                } 
            }
        }

        protected void btFiltrar_Click(object sender, EventArgs e)
        {
            if(espaciosLlenos1())
            {
                if (platos.verificarNombrePlato(tbFilter.Text))
                {
                    gvMenu.DataSource = platos.buscarConFiltro(tbFilter.Text);
                    gvMenu.DataBind();
                }
                else
                {
                    Type cstype = this.GetType();

                    ClientScriptManager cs = Page.ClientScript;

                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Este Plato No Existe');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            }
            else
            {
                gvMenu.DataSource = platos.listaPlatos();
                gvMenu.DataBind();
            }     
        }

        public Boolean espaciosLlenos1()
        {
            if (tbFilter.Text == "")
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

        public Boolean espaciosLlenos2()
        {
            if (tbId.Text == "")
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