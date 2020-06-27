using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    class GestorPedidos
    {
        public dynamic consultaPedidosSinFiltro()
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            var pedidos = from Pedido in dc.Pedido
                          select Pedido;

            return pedidos;
        }

        public dynamic consultaPedidosCocnFiltro(int filtro, int client, DateTime fechaA, DateTime fechaB, int porEstado)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);


            if (filtro == 1)
            {
                if (client != 0)
                {
                    var pedidos = from pedido in dc.Pedido
                                  where pedido.UsuarioID == client
                                  select pedido;
                    return pedidos;

                }
                else if (porEstado != 0)
                {

                    var pedidos = from pedido in dc.Pedido
                                  where pedido.EstadoPedidoID == porEstado
                                  select pedido;
                    return pedidos;
                }
                else
                {

                    var pedidos = from pedido in dc.Pedido
                                  where pedido.FechaPedido >= fechaA
                                  where pedido.FechaPedido <= fechaB
                                  select pedido;
                    return pedidos;

                }


            }
            else if (filtro == 2)
            {
                if (client != 0 && porEstado != 0)
                {
                    var pedidos = from pedido in dc.Pedido
                                  where pedido.UsuarioID == client
                                  where pedido.EstadoPedidoID == porEstado
                                  select pedido;
                    return pedidos;
                }
                else if (client != 0 && fechaA != null)
                {
                    var pedidos = from pedido in dc.Pedido
                                  where pedido.UsuarioID == client
                                  where pedido.FechaPedido >= fechaA
                                  where pedido.FechaPedido <= fechaB
                                  select pedido;
                    return pedidos;

                }
                else
                {

                    var pedidos = from pedido in dc.Pedido
                                  where pedido.EstadoPedidoID == porEstado
                                  where pedido.FechaPedido >= fechaA
                                  where pedido.FechaPedido <= fechaB
                                  select pedido;
                    return pedidos;
                }

            }
            else
            {

                var pedidos = from pedido in dc.Pedido
                              where pedido.UsuarioID == client
                              where pedido.FechaPedido >= fechaA
                              where pedido.FechaPedido <= fechaB
                              where pedido.EstadoPedidoID == porEstado
                              select pedido;

                return pedidos;

            }
            return null;
        }
    }
}
