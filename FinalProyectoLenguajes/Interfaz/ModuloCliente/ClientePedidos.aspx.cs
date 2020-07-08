using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoDatos;
using LogicaNegocio;

namespace Interfaz.ModuloCliente
{
    public partial class ClientePedidos : System.Web.UI.Page
    {
        AdministracionPedidos pedidos = new AdministracionPedidos();
        AdministracionPlatos platos = new AdministracionPlatos();
        AdministracionUsuarios gestionUsuario = new AdministracionUsuarios();
        Plato platoBuscado = new Plato();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvMenu.DataSource = platos.listPlatos();
            gvMenu.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloCliente/ClienteMainMenu.aspx?usuario=" + (String)Session["temporal1"]);
        }

        protected void bt_Click(object sender, EventArgs e)
        {

            if (espaciosVacios())
            {   
                if(pedidos.esNumero(tbDishID.Text) && pedidos.esNumero(tbCant.Text))
                {
                    if (platos.validarPlato(int.Parse(tbDishID.Text)))
                    {
                        platoBuscado = platos.buscarPlato(int.Parse(tbDishID.Text));

                        if (platoBuscado == null)
                        {
                            Type cstype = this.GetType();

                            ClientScriptManager cs = Page.ClientScript;

                            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                            {
                                String cstext = "alert('El platoID ingresado no coincide con ningún plato');";
                                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                            }
                        }
                        else
                        {
                            PlatoInfo platoNuevo = new PlatoInfo(int.Parse(tbDishID.Text), int.Parse(tbCant.Text),
                            (pedidos.getLastPedidoID().PedidoID + 1), platoBuscado.Precio, platoBuscado.Nombre);

                            if (((ListPlatoInfo)Session["TempLista"]).contienePlato(platoNuevo.getPlatoID()))
                            {
                                ((ListPlatoInfo)Session["TempLista"]).setCantidadPlatoExistente(platoNuevo.getCantidadPlato(), platoNuevo.getPlatoID());
                            }
                            else
                            {
                                ((ListPlatoInfo)Session["TempLista"]).addPlato(platoNuevo);
                            }

                            gvCarrito.DataSource = ((ListPlatoInfo)Session["TempLista"]).GetListPlatoInfo();
                            gvCarrito.DataBind();
                        }

                    }
                    else
                    {
                        Type cstype = this.GetType();

                        ClientScriptManager cs = Page.ClientScript;

                        if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                        {
                            String cstext = "alert('El platoID ingresado no coincide con ningún plato');";
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
                        String cstext = "alert('valores invalidos');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            }
        }

        public Boolean espaciosVacios()
        {
            if (tbDishID.Text == "" || tbCant.Text == "")
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


        public Boolean espaciosVaciosDatosCarrito()
        {
            if (txtPedidoID.Text == "" || txtCantidad.Text == "")
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

        public Boolean espaciosVaciosOpcEliminar()
        {
            if (txtPedidoID.Text == "")
            {
                Type cstype = this.GetType();

                ClientScriptManager cs = Page.ClientScript;

                if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                {
                    String cstext = "alert('Debe de ingresar el PlatoID del plato que desea eliminar de su pedido');";
                    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                }
                return false;
            }
            return true;
        }

        protected void btnModificar_Click1(object sender, EventArgs e)
        {

            if (espaciosVaciosDatosCarrito())
            {
                if (pedidos.esNumero(txtPedidoID.Text) && pedidos.esNumero(txtCantidad.Text))
                {
                    if (platos.validarPlato(int.Parse(txtPedidoID.Text)))
                    {
                        if (((ListPlatoInfo)Session["TempLista"]).contienePlato(int.Parse(txtPedidoID.Text)))
                        {
                            ((ListPlatoInfo)Session["TempLista"]).modificarCantidadPlatos(int.Parse(txtCantidad.Text), int.Parse(txtPedidoID.Text));
                        }
                        else
                        {
                            Type cstype = this.GetType();

                            ClientScriptManager cs = Page.ClientScript;

                            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                            {
                                String cstext = "alert('El platoID ingresado no coincide con nigún plato de su lista');";
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
                            String cstext = "alert('El platoID ingresado no coincide con ningún plato');";
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
                        String cstext = "alert('valores invalidos');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            gvMenu.DataSource = platos.listPlatos();
            gvMenu.DataBind();
            gvCarrito.DataSource = ((ListPlatoInfo)Session["TempLista"]).GetListPlatoInfo();
            gvCarrito.DataBind();
        }
        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            if (espaciosVaciosOpcEliminar())
            {
                if (pedidos.esNumero(txtPedidoID.Text) && pedidos.esNumero(txtCantidad.Text))
                {
                    if (platos.validarPlato(int.Parse(txtPedidoID.Text)))
                    {
                        if (((ListPlatoInfo)Session["TempLista"]).contienePlato(int.Parse(txtPedidoID.Text)))
                        {
                            ((ListPlatoInfo)Session["TempLista"]).eliminarPlato(((ListPlatoInfo)Session["TempLista"]).getPlato(int.Parse(txtPedidoID.Text)));
                        }
                        else
                        {
                            Type cstype = this.GetType();

                            ClientScriptManager cs = Page.ClientScript;

                            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                            {
                                String cstext = "alert('El platoID ingresado no coincide con nigún plato de su lista');";
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
                            String cstext = "alert('El platoID ingresado no coincide con ningún plato');";
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
                        String cstext = "alert('valores invalidos');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }
            }
            gvMenu.DataSource = platos.listPlatos();
            gvMenu.DataBind();
            gvCarrito.DataSource = ((ListPlatoInfo)Session["TempLista"]).GetListPlatoInfo();
            gvCarrito.DataBind();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (((ListPlatoInfo)Session["TempLista"]).isEmpty() == false)
            {
                lbAlerta.Text = "Pedido Agregado Con Exito";
                string nombreActual = Session["temporal1"].ToString();
                Usuario actual = gestionUsuario.obtenerUsuario(nombreActual);

                pedidos.insertarPedido(1, actual.UsuarioID);

                ListPlatoInfo listaFinal = new ListPlatoInfo();

                listaFinal = ((ListPlatoInfo)Session["TempLista"]);
                foreach (PlatoInfo info in listaFinal.GetListPlatoInfo())
                {
                    platos.insertarPedido_Plato(info.getCantidadPlato(), info.getPlatoID(), info.getPedidoID());
                }
                Thread.Sleep(3000);
                Response.Redirect("~/ModuloCliente/ClienteMainMenu.aspx?");
            }
            else
            {


                Type cstype = this.GetType();

                ClientScriptManager cs = Page.ClientScript;

                if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                {
                    String cstext = "alert('Debe de agregar platos a su pedido');";
                    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                }
            }
        }
    }
}