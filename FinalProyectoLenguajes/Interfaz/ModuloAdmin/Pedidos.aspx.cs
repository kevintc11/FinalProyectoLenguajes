using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;

namespace Interfaz.ModuloAdmin
{
    public partial class Pedidos : System.Web.UI.Page
    {

        private Boolean filtroCliente;
        private Boolean filtroFecha;
        private Boolean filtroEstado;

        protected void Page_Load(object sender, EventArgs e)
        {
            filtroCliente = false;
            filtroFecha = false;
            filtroEstado = false;
            dgPedidos.DataSource = metodosP.Pedidos();
            dgPedidos.DataBind();
        }

        AdministracionPlatos metodosP = new AdministracionPlatos();

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/MenuAdmin.aspx?usuario=" + (string)Session["temporal1"]);
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cblFilter.SelectedIndex == 0)
            {

            }
            else if (cblFilter.SelectedIndex == 1)
            {

            }
            else if (cblFilter.SelectedIndex == 2)
            {

            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            revisarListOptions();
            dgPedidos.DataSource = metodoFiltro();
            dgPedidos.DataBind();
        }

        public void revisarListOptions()
        {

            int valueOpcion = 0;
            for (int i = 0; i < cblFilter.Items.Count; i++)
            {

                if (cblFilter.Items[i].Selected)
                {
                    valueOpcion = int.Parse(cblFilter.Items[i].Value);
                    if (valueOpcion == 1)
                    {
                        filtroCliente = true;
                    }
                    else if (valueOpcion == 2)
                    {
                        filtroFecha = true;
                    }
                    else
                    {
                        filtroEstado = true;
                    }
                }

            }
        }

        public dynamic metodoFiltro()
        {
            if (filtroCliente)
            {
                if (espaciosVacios1())
                {
                    if (filtroFecha)
                    {
                        if (isFecha(txDate1.Text) && isFecha(txDate2.Text))
                        {
                            if (filtroEstado)
                            {
                                if (metodosP.esNumero(txName.Text))
                                {
                                    return metodosP.PedidosConFiltro(3, int.Parse(txName.Text), txDate1.Text,
                                                            txDate2.Text, int.Parse(rblStatus.SelectedValue));
                                }
                                else
                                {
                                    Type cstype = this.GetType();

                                    ClientScriptManager cs = Page.ClientScript;

                                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                                    {
                                        String cstext = "alert('Por favor escriba el formato correcto');";
                                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                                    }
                                }
                            }
                            if (metodosP.esNumero(txName.Text))
                            {
                                return metodosP.PedidosConFiltro(2, int.Parse(txName.Text), txDate1.Text,
                                                            txDate2.Text, 0);
                            }
                            else
                            {
                                Type cstype = this.GetType();

                                ClientScriptManager cs = Page.ClientScript;

                                if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                                {
                                    String cstext = "alert('Por favor escriba el formato correcto');";
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
                                String cstext = "alert('Por favor escriba el formato correcto');";
                                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                            }
                        }


                    }
                    else if (filtroEstado)
                    {
                        if (metodosP.esNumero(txName.Text))
                        {
                            return metodosP.PedidosConFiltro(2, int.Parse(txName.Text), "",
                                                        "", int.Parse(rblStatus.SelectedValue));
                        }
                        else
                        {
                            Type cstype = this.GetType();

                            ClientScriptManager cs = Page.ClientScript;

                            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                            {
                                String cstext = "alert('Por favor escriba el formato correcto');";
                                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                            }
                        }

                    }
                    if (metodosP.esNumero(txName.Text))
                    {
                        return metodosP.PedidosConFiltro(1, int.Parse(txName.Text), "",
                                                        "", 0);
                    }
                    else
                    {
                        Type cstype = this.GetType();

                        ClientScriptManager cs = Page.ClientScript;

                        if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                        {
                            String cstext = "alert('Por favor escriba el formato correcto');";
                            cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                        }
                    }

                }

            }
            else if (filtroFecha)
            {
                if (isFecha(txDate1.Text) && isFecha(txDate2.Text))
                {
                    if (espaciosVaciosFecha())
                    {
                        if (filtroEstado)
                        {
                            return metodosP.PedidosConFiltro(2, 0, txDate1.Text,
                                                            txDate2.Text, int.Parse(rblStatus.SelectedValue));
                        }
                        return metodosP.PedidosConFiltro(1, 0, txDate1.Text,
                                                            txDate2.Text, 0);
                    }
                }
                else
                {
                    Type cstype = this.GetType();

                    ClientScriptManager cs = Page.ClientScript;

                    if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    {
                        String cstext = "alert('Por favor escriba el formato de fecha correcto');";
                        cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    }
                }

            }
            else if (filtroEstado)
            {

                return metodosP.PedidosConFiltro(1, 0, "",
                                                    "", int.Parse(rblStatus.SelectedValue));
            }
            else
            {
                return metodosP.Pedidos();
            }
            return metodosP.Pedidos();
        }

        public static bool isFecha(object Expression)
        {
            try
            {
                bool isFecha;
                DateTime retDate;
                isFecha = DateTime.TryParse(Convert.ToString(Expression), out retDate);
                return isFecha;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Boolean espaciosVacios1()
        {
            if (txName.Text == "")
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

        public Boolean espaciosVaciosFecha()
        {
            if (txDate1.Text == "" && txDate2.Text == "")
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