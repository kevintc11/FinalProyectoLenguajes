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
            if (pedidos.getCantidadPedidos()>=5 && pedidos.getCantidadPedidos() <= 10)
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
                UpdatePanel6.Update();
               
            }
            else if(pedidos.getCantidadPedidos() > 10)
            {
                lbError.Text = "Existen más platos en espera de ser procesados";
            }
            else
            {
                //hay menores de 5 entonces esta vara esta vacia entonces poner mensaje
                lbError.Text = "La cantidad de platos es menor a 5 por lo que no se muestra ninguno";
            }
            
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
            while (Session["Name_Cliente"] != null)
            {
                pedidos.cambiarEstadoPedAutomatic(int.Parse(DateTime.Now.Minute.ToString()));
                cambiarColores();
                dgPedidos.DataSource = pedidos.pedidosActivos();
                dgPedidos.DataBind();
                Thread.Sleep(30000);
            }
            tAct.Abort();
        }

        protected void btSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InicioSesion.aspx");
        }

        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            UpdatePanel6.Update();
        }
    }
}