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
        GestorUsuarios usuarios = new GestorUsuarios();

        public Boolean esNumero(object x)
        {
            return usuarios.esNumero(x);
        }

        public dynamic buscarPlato2(int platoID)
        {
            return gestor.buscarPlato2(platoID);
        }

        public dynamic buscarPlato(int platoID)
        {
            return gestor.buscarPlato(platoID);
        }

        public void insertarPlato(bool isAdd, int platoID, string nombre, string descPlato, int precio, int estado, byte[] foto, int activo)
        {
            gestor.modifInsertPlato(isAdd, platoID, nombre, descPlato, precio, estado, foto, activo);
        }

        public void modificarPlato(bool isAdd, int platoID, string nombre, string descPlato, int precio, int estado, byte[] foto, int activo)
        {
            gestor.modifInsertPlato(isAdd, platoID, nombre, descPlato, precio, estado, foto, activo);
        }

        public void eliminarPlato(int platoID)
        {
            gestor.eliminarPlato(platoID);
        }

        public dynamic buscarConFiltro(string platillo)
        {
            return gestor.buscarPlatoFiltro(platillo);
        }

        public Boolean verificarNombrePlato(string platillo)
        {
            return gestor.verificarPlatoNombre(platillo);
        }

        public dynamic listaPlatos()
        {
            return gestor.listPlatos();
        }

        public dynamic Pedidos()
        {
            return pedidos.consultaPedidosSinFiltro();
        }

        public dynamic PedidosConFiltro(int filtro, int cliente,string fechaA, string fechaB, int estado)
        {
            return pedidos.consultaPedidosCocnFiltro(filtro, cliente,fechaA,fechaB,estado);
        }

        public byte[] mostrarImagen(int platoID)
        {
            return gestor.mostrarImagen(platoID);
        }

        public dynamic listPlatos()
        {
            return gestor.listPlatosActivos();
        }
    }
}
