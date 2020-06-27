using System;
using System.Collections.Generic;
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
    }
}
