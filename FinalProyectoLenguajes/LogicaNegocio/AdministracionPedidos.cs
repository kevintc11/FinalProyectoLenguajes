﻿using System;
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
        GestorUsuarios usuarios = new GestorUsuarios();

        public int getCantidadPedidos()
        {
            return pedidos.getNumeroPedidos();
        }

        public dynamic pedidosActivos()
        {
            return pedidos.GetListPedidosActivos();
        }

        public void actualizarEstadoPedido(int pedidoID, int estadoID)
        {
            pedidos.actualizarEstadoPedido(pedidoID, estadoID);
        }

        public int estadoPedidoID (string pedidoID)
        {
            return pedidos.getPedido(int.Parse(pedidoID)).EstadoPedidoID;
        }

        public Boolean comprobarPedido(string pedidoID)
        {
            if(pedidos.getPedido(int.Parse(pedidoID)) != null)
            {
                return true;
            }
            return false;
        }

        public Boolean esNumero(String dato)
        {
            return usuarios.esNumero(dato);
        }

        public void cambiarEstadoPedAutomatic(int hora)
        {
            pedidos.actualizarAutomatic(hora);
        }

        public Pedido getLastPedidoID()
        {
            return pedidos.GetLastPedido();
        }

        public void insertarPedido(int estadoID, int usuarioID)
        {
            pedidos.insertarPedido(estadoID,usuarioID);
        }

        public void cambiarTiempoPedido(int estadoID, int tiempo)
        {
            pedidos.CambiarEstadoID(estadoID, tiempo);
        }

        public dynamic getTiempoEstadoPedido(int estadoPedidoID)
        {
            return pedidos.getTiempoEstadoPedido(estadoPedidoID);
        }

        public dynamic getEstadoPedidos()
        {
            return pedidos.getListEstados();
        }
    }
}
