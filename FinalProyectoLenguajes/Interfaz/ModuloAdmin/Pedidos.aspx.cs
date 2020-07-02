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
        protected void Page_Load(object sender, EventArgs e)
        {
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
            dgPedidos.DataSource = metodoFiltro();
            dgPedidos.DataBind();
        }

        public dynamic metodoFiltro()
        {


            if (cblFilter.SelectedIndex == 0)
            {
                if(espaciosVacios1())
                {
                    if (cblFilter.SelectedIndex == 1)
                    {
                        if (cblFilter.SelectedIndex == 2)
                        {
                            return metodosP.PedidosConFiltro(3, int.Parse(txName.Text), txDate1.Text,
                                                        txDate2.Text, int.Parse(rblStatus.SelectedValue));
                        }
                        return metodosP.PedidosConFiltro(2, int.Parse(txName.Text), txDate1.Text,
                                                        txDate2.Text, 0);
                    }
                    return metodosP.PedidosConFiltro(1, int.Parse(txName.Text), txDate1.Text,
                                                        txDate2.Text, 0);
                }
            }
            else if (cblFilter.SelectedIndex == 1)
            {
                if (espaciosVaciosFecha())
                {
                    if (cblFilter.SelectedIndex == 2)
                    {
                        return metodosP.PedidosConFiltro(2, 0, txDate1.Text,
                                                        txDate2.Text, int.Parse(rblStatus.SelectedValue));
                    }
                    return metodosP.PedidosConFiltro(2, 0, txDate1.Text,
                                                        txDate2.Text, 0);
                }
            }
            else if (cblFilter.SelectedIndex == 2)
            {
                return metodosP.PedidosConFiltro(1, 0, txDate1.Text,
                                                    txDate2.Text, int.Parse(rblStatus.SelectedValue));
            }else
            {
                return metodosP.Pedidos();
            }
            return metodosP.Pedidos();
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