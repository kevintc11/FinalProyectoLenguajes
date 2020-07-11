using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            tbDishName.Enabled = false;
            tbDesc.Enabled = false;
            tbPrice.Enabled = false;
            fuPhoto.Enabled = false;
            rdEstado.Enabled = false;
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/PlatoMenu.aspx");
        }

        protected void btMod_Click(object sender, EventArgs e)
        {
           
            if (espaciosVacios1() == true)
            {
                try
                {
                    try
                    {

                        if (platos.esNumero(tbPlatoID.Text))
                        {
                            
                            platos.buscarPlato(int.Parse(tbPlatoID.Text));
                        }
                        else
                        {
                            Type cstype = this.GetType();
                            ClientScriptManager cs = Page.ClientScript;
                            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                            {
                                String cstext = "alert('El platoID debe ser un número');";
                                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw new Exception("El plato no existe");
                    }
           
                    if (platos.buscarPlato(int.Parse(tbPlatoID.Text)) != null)
                    {
                        if(fuPhoto.FileName != "")
                        {
                            
                            platos.modificarPlato(false, int.Parse(tbPlatoID.Text), tbDishName.Text, tbDesc.Text, int.Parse(tbPrice.Text), int.Parse(rdEstado.SelectedValue), fuPhoto.FileBytes, 1);
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
                            Plato pl = platos.buscarPlato(int.Parse(tbPlatoID.Text));
                            platos.modificarPlato(false, int.Parse(tbPlatoID.Text), tbDishName.Text, tbDesc.Text, int.Parse(tbPrice.Text), int.Parse(rdEstado.SelectedValue),pl.Foto, 1);
                            Type cstype = this.GetType();
                            ClientScriptManager cs = Page.ClientScript;
                            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                            {
                                String cstext = "alert('Plato modificado correctamente');";
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

        public Boolean espaciosVacios1()
        {
            if (tbDishName.Text == "" || tbDesc.Text == "" || tbPrice.Text == "")
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

        public Boolean espaciosVacios2()
        {
            if (tbPlatoID.Text == "")
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
            if (espaciosVacios2())
            {
                if (platos.esNumero(tbPlatoID.Text))
                {
                    if (platos.buscarPlato(int.Parse(tbPlatoID.Text)) != null)
                    {
                        tbDishName.Enabled = true;
                        tbDesc.Enabled = true;
                        tbPrice.Enabled = true;
                        fuPhoto.Enabled = true;
                        rdEstado.Enabled = true;
                        Plato pli = platos.buscarPlato(int.Parse(tbPlatoID.Text));
                        tbDishName.Text = pli.Nombre;
                        tbDesc.Text = pli.DescPlato;
                        string[] precioD = pli.Precio.ToString().Split('.');
                        string precio = precioD[0];


                        tbPrice.Text = precio;
                        btnComprobar.Enabled = false;
                        tbPlatoID.Enabled = false;
                        byte[] imageData = platos.mostrarImagen(int.Parse(tbPlatoID.Text));
                        string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                        imgPlato.ImageUrl = "data:image/png;base64," + img;
                    }
                    else
                    {
                        Type cstype = this.GetType();

                        ClientScriptManager cs = Page.ClientScript;

                        if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                        {
                            String cstext = "alert('El plato no existe');";
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
                        String cstext = "alert('Debe digitar solamente números');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            }
        }
    }
}