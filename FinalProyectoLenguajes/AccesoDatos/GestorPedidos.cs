using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AccesoDatos
{
    public class GestorPedidos
    {


        public int getNumeroPedidos()
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            var pedidos = (from pedido in dc.Pedido
                           where pedido.EstadoPedidoID <= 3
                           orderby pedido.FechaPedido descending
                           select pedido).Count();
            int count = (int)pedidos;
            return pedidos;

        }

        public dynamic GetLastPedido()
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            var pedidos = from pedido in dc.Pedido
                       orderby pedido.PedidoID descending
                       select pedido;

            return pedidos.First();
        }


        public Pedido getPedido(int pedidoID)
        {
            try
            {
                LectArchivo lectura1 = new LectArchivo();
                SqlConnectionStringBuilder conect = lectura1.leerServer1();
                SqlConnection conexion = new SqlConnection(conect.ConnectionString);
                DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

                var pedidos = (from pedido in dc.Pedido
                               where pedido.PedidoID == pedidoID
                               select pedido).Single();
                return pedidos;
            }
            catch
            {
                return null;
            }
        }


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

        public dynamic consultaPedidosCocnFiltro(int filtro, int client, string fechaA, string fechaB, int porEstado)
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
                                  where pedido.FechaPedido >= DateTime.Parse(fechaA) 
                                  where pedido.FechaPedido <= DateTime.Parse(fechaB)
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
                else if (client != 0 && fechaA != "")
                {
                    var pedidos = from pedido in dc.Pedido
                                  where pedido.UsuarioID == client
                                  where pedido.FechaPedido >= DateTime.Parse(fechaA)
                                  where pedido.FechaPedido <= DateTime.Parse(fechaB)
                                  select pedido;
                    return pedidos;

                }
                else
                {

                    var pedidos = from pedido in dc.Pedido
                                  where pedido.EstadoPedidoID == porEstado
                                  where pedido.FechaPedido >= DateTime.Parse(fechaA)
                                  where pedido.FechaPedido <= DateTime.Parse(fechaB)
                                  select pedido;
                    return pedidos;
                }

            }
            else
            {
                var pedidos = from pedido in dc.Pedido
                              where pedido.UsuarioID == client
                              where pedido.FechaPedido >= DateTime.Parse(fechaA)
                              where pedido.FechaPedido <= DateTime.Parse(fechaB)
                              where pedido.EstadoPedidoID == porEstado
                              select pedido;

                return pedidos;
            }
        }

        public void actualizarEstadoPedido(int pedidoID, int estadoID)
        {

            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            

            if (verificarEstadoPedido(estadoID) && verificarPedido(pedidoID))
            {
                Pedido pedido = dc.Pedido.First(ped => ped.PedidoID.Equals(pedidoID));

                pedido.EstadoPedidoID = Convert.ToInt16(estadoID);
                dc.SubmitChanges();
                dc.Connection.Close();
            }

        }
        public EstadoPedido getEstado(int estadoID)
        {
            if (verificarEstadoPedido(estadoID))
            {
                LectArchivo lectura1 = new LectArchivo();
                SqlConnectionStringBuilder conect = lectura1.leerServer1();
                SqlConnection conexion = new SqlConnection(conect.ConnectionString);
                DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
                EstadoPedido estadoPedido = dc.EstadoPedido.First(clie => clie.EstadoPedidoID.Equals(estadoID));
                return estadoPedido;
            }
            else
            {
                return null;
            }
        }

        public Boolean verificarEstadoPedido(int estadoID)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            try
            {
                EstadoPedido estadoPedido = dc.EstadoPedido.First(clie => clie.EstadoPedidoID.Equals(estadoID));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean verificarPedido(int pedidoID)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            try
            {
                Pedido pedido = dc.Pedido.First(ped => ped.PedidoID.Equals(pedidoID));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public dynamic GetListPedidosActivos()
        {

            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            var pedidos = (from pedidoXplato in dc.Pedido_X_Plato
                          join pedido in dc.Pedido on pedidoXplato.PedidoID equals pedido.PedidoID
                          join plato in dc.Plato on pedidoXplato.PlatoID equals plato.PlatoID
                          join usuario in dc.Usuario on pedido.UsuarioID equals usuario.UsuarioID
                          join estado in dc.EstadoPedido on pedido.EstadoPedidoID equals estado.EstadoPedidoID
                           where pedido.EstadoPedidoID <= 3
                          orderby pedido.FechaPedido descending
                          select new
                          {
                              usuario.NombreCompleto,
                              plato.PlatoID
                          ,
                              plato.Nombre,
                              plato.DescPlato,
                              pedido.FechaPedido,
                              pedido.PedidoID,
                              pedido.EstadoPedidoID,
                              estado.DescEstadoPedido
                          }).Take(5);
            return pedidos;
        }

        public void actualizarAutomatic(int horaActual)
        {

            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            var pedidos = from Pedido in dc.Pedido
                          where Pedido.EstadoPedidoID < 4
                          select Pedido;

            foreach (var pedido in pedidos)
            {
                cambiarEstadoPedidoAutomatic(pedido.PedidoID, horaActual);
            }


        }

        public void cambiarEstadoPedidoAutomatic(int pedidoID, int horaAct)
        {

            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            Pedido pedido = dc.Pedido.First(ped => ped.PedidoID.Equals(pedidoID));

            int tiempoPedido = int.Parse(pedido.FechaPedido.Minute.ToString());
            Boolean esMayor = false;

            if (horaAct > tiempoPedido)
            {
                esMayor = true;
            }


            if (horaAct != tiempoPedido && pedido.EstadoPedidoID < 3)
            {
                int tiempoTranscurrido = 0;
                EstadoPedido est1 = getTiempoEstadoPedido(1);
                EstadoPedido est2 = getTiempoEstadoPedido(2);
                if (esMayor)
                {

                    tiempoTranscurrido = (horaAct - tiempoPedido);

                   

                    if (tiempoTranscurrido < est1.TiempoCambioEstado)
                    {
                        pedido.EstadoPedidoID = 1;
                    }
                    else if (tiempoTranscurrido < est2.TiempoCambioEstado)
                    {
                        pedido.EstadoPedidoID = 2;
                    }
                    else
                    {
                        pedido.EstadoPedidoID = 3;
                    }

                }
                else
                {

                    tiempoTranscurrido = (horaAct - tiempoPedido) + 60;
                    if (tiempoTranscurrido < est1.TiempoCambioEstado)
                    {
                        pedido.EstadoPedidoID = 1;
                    }
                    else if (tiempoTranscurrido < est2.TiempoCambioEstado)
                    {
                        pedido.EstadoPedidoID = 2;
                    }
                    else
                    {
                        pedido.EstadoPedidoID = 3;
                    }

                }
                dc.SubmitChanges();
                dc.Connection.Close();

            }


        }

        public dynamic getTiempoEstadoPedido(int estadoPedidoID)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            var estadoPedidos = (from EstadoPedido in dc.EstadoPedido
                                 where EstadoPedido.EstadoPedidoID == estadoPedidoID
                                 select EstadoPedido).Single();

            return estadoPedidos;
        }

        public void insertarPedido(int estadoPedidoID, int usuarioID)
        {


            DateTime date2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            LectArchivo lectura1 = new LectArchivo();

            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            Pedido pedido = new Pedido();


            pedido.FechaPedido = date2;

            pedido.EstadoPedidoID = Convert.ToInt16(estadoPedidoID);
            pedido.UsuarioID = Convert.ToInt16(usuarioID);


            dc.Pedido.InsertOnSubmit(pedido);
            dc.SubmitChanges();
            dc.Connection.Close();

        }

        public void CambiarEstadoID(int estadoID, int tiempoCambio)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            var estados = (from estado in dc.EstadoPedido
                           where estado.EstadoPedidoID == estadoID
                           select estado).Single();

            estados.TiempoCambioEstado = Convert.ToInt16(tiempoCambio);
            dc.SubmitChanges();
            dc.Connection.Close();
        }

        public dynamic getListEstados()
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            var estados = (from estado in dc.EstadoPedido
                           where estado.EstadoPedidoID <= 2
                           select estado).ToList();
            return estados;
        }

        public DateTime GetDateTime()
        {

            LectArchivo lectura1 = new LectArchivo();

            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            //DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            using (DataClasses1DataContext dc = new DataClasses1DataContext(conexion))
            {
                var dQuery = dc.ExecuteQuery<DateTime>("SELECT getdate()");
                return dQuery.AsEnumerable().First();
            }

        }
    }
}
