using AccesoDatos;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
                        Plato pli = platos.buscarPlato(int.Parse(tbId.Text));
                        lbName.Text = pli.Nombre;
                        lbDesc.Text = pli.DescPlato;
                        lbPrice.Text = pli.Precio.ToString();
                        string ruta = Server.MapPath("~/Imagen/");
                        ruta = Path.Combine(ruta, "plato.png");
                        MemoryStream ms = new MemoryStream(platos.mostrarImagen(int.Parse(tbId.Text)));
                        Bitmap imagenBit = (Bitmap)System.Drawing.Image.FromStream(ms);
                        imagenBit.Save(ruta, ImageFormat.Png);
                        imgPlato.ImageUrl = ("~/Imagen/plato.png");
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

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloCliente/ClienteMainMenu.aspx?usuario=" + (String)Session["temporal1"]);
        }
    }
}