using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaNegocio
{
    public class MetodosInterfaz
    {
        GestorUsuarios mUsers = new GestorUsuarios();

        public Boolean comprobarCorreo(String correo)
        {
            return mUsers.comprobarCorreo(correo);
        }
    }
}
