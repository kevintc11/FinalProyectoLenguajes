using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaNegocio
{
    public class AdministracionPedidos
    {

        GestorPedidos pedidos = new GestorPedidos();

        public dynamic pedidosActivos()
        {
            return pedidos.GetListPedidosActivos();
        }

        public void actualizarEstadoPedido(int pedidoID, int estadoID)
        {
            pedidos.actualizarEstadoPedido(pedidoID, estadoID);
        }
    }
}
