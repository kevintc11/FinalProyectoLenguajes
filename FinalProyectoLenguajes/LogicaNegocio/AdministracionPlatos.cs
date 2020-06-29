using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaNegocio
{
    public class AdministracionPlatos
    {
        GestorPlatos gestor = new GestorPlatos();
        GestorPedidos pedidos = new GestorPedidos();
        
        public dynamic buscarPlato(int platoID)
        {
            return gestor.buscarPlato(platoID);
        }

        public void insertarPlato(bool isAdd, int platoID, string nombre, string descPlato, int precio, int estado, string foto, int activo)
        {
            gestor.modifInsertPlato(isAdd, platoID, nombre, descPlato, precio, estado, foto, activo);
        }

        public void modificarPlato(bool isAdd, int platoID, string nombre, string descPlato, int precio, int estado, string foto, int activo)
        {
            gestor.modifInsertPlato(isAdd, platoID, nombre, descPlato, precio, estado, foto, activo);
        }

        public void eliminarPlato(int platoID)
        {
            gestor.buscarPlato(platoID);
        }

        public dynamic Pedidos()
        {
            return pedidos.consultaPedidosSinFiltro();
        }

        public dynamic PedidosConFiltro(int filtro, int cliente,string fechaA, string fechaB, int estado)
        {
            return pedidos.consultaPedidosCocnFiltro(filtro, cliente,fechaA,fechaB,estado);
        }
    }
}
