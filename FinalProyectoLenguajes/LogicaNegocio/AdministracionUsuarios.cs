using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaNegocio
{
    public class AdministracionUsuarios
    {
        GestorUsuarios mUsers = new GestorUsuarios();

        public Boolean comprobarCorreo(String correo)
        {
            return mUsers.comprobarCorreo(correo);
        }

        public Boolean comprobarUsuario(String nombreUsuario)
        {
            try
            {
                return mUsers.comprobarUsuario(nombreUsuario);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public int tipoUsuario(string nickname)
        {
            Usuario user = mUsers.consultaUsuario(nickname);
            return user.TipoUsuarioID;
        }

        public void insertarUsuario(string nombreUsuario, string correoElectronico, string nombreCompleto,
                                    string contraseña, int tipoUsuario, string direccion)
        {
            mUsers.insertarUsuario(nombreUsuario, correoElectronico, nombreCompleto, contraseña, tipoUsuario, direccion);
        }

        public Boolean iniciarSesion(string nickname, string password)
        {
            try
            {
                return mUsers.iniciarSesión(nickname, password);
            }
            catch (Exception)
            {
                throw new Exception("Contraseña O Usuario Inválida");
            }
        }
    }
}
