using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;

namespace Interfaz.ModuloCocinero
{
    public partial class PedidosActivos : System.Web.UI.Page
    {

        Thread tAct;
        int idTempPedido;
        int idTempestado;
        string dato = "false";
        AdministracionPedidos pedidos = new AdministracionPedidos();
        protected void Page_Load(object sender, EventArgs e)
        {
            string iniciaHilo = (string)Session["hilo"];
            if (iniciaHilo == "true")
            {
                lblHilo.Text = "2";
                Session["hilo"] = dato;
                tAct = new Thread(hiloAct);
                tAct.Start();
            }
            btnDeshacer.Enabled = false;
            dgPedidos.DataSource = pedidos.pedidosActivos();
            dgPedidos.DataBind();
            cambiarColores();
        }

        protected void dgPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cambiarColores()
        {
            foreach (GridViewRow row in dgPedidos.Rows)
            {
                string valor = dgPedidos.Rows[row.RowIndex].Cells[6].Text;
                int value = int.Parse(valor);
                if (value == 1)
                {
                    dgPedidos.Rows[row.RowIndex].BackColor = Color.Green;
                }
                else if (value == 2)
                {
                    dgPedidos.Rows[row.RowIndex].BackColor = Color.Yellow;
                }
                else if (value == 3)
                {
                    dgPedidos.Rows[row.RowIndex].BackColor = Color.Red;
                }
            }
        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
           
            if (espaciosVacios())
            {
                ejecucion();
                cambiarColores();
            }
        }

        public void ejecucion()
        {
                if (pedidos.esNumero(tbPedidoID.Text))
                {
                    if (pedidos.comprobarPedido(tbPedidoID.Text))
                    {
                        btnDeshacer.Enabled = true;
                        Session["temporal1"] = pedidos.estadoPedidoID(tbPedidoID.Text);
                            //pedidos.estadoPedidoID(tbPedidoID.Text);
                        pedidos.actualizarEstadoPedido(int.Parse(tbPedidoID.Text), 5);
                        Session["temporal2"] = int.Parse(tbPedidoID.Text);
                        dgPedidos.DataSource = pedidos.pedidosActivos();
                        dgPedidos.DataBind();
                        lbError.Text = "El pedido fue entregado";
                    }
                    else
                    {
                        lbError.Text = "El pedido no existe";
                    }
                }
                else
                {
                    lbError.Text = "Valor Invalido";
                }
        }

        public void reinicar()
        {
            int idTempPedido = (int)Session["temporal2"];
            int idTempestado = (int)Session["temporal1"];
            pedidos.actualizarEstadoPedido(idTempPedido, idTempestado);
            dgPedidos.DataSource = pedidos.pedidosActivos();
            dgPedidos.DataBind();
            lbError.Text = "Cambios Desechos";
        }

        public Boolean espaciosVacios()
        {
            if (tbPedidoID.Text == "")
            {
                lbError.Text = "Por favor rellene todos los campos";
                return false;
            }
            return true;
        }

        protected void btnDeshacer_Click(object sender, EventArgs e)
        {
            reinicar();
            cambiarColores();
            btnDeshacer.Enabled = false;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            int valor  = int.Parse(DateTime.Now.Second.ToString());
            //Label2.Text = valor + "";
        }

        protected void hiloAct()
        {
            for (int i = 0; i < 2; i++)
            {
                cambiarColores();
                pedidos.cambiarEstadoPedAutomatic(int.Parse(DateTime.Now.Minute.ToString()));
                Thread.Sleep(6000);
            }
            tAct.Abort();
        }

        protected void btSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InicioSesion.aspx");
        }
    }
}