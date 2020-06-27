using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AccesoDatos
{
    class GestorUsuarios
    {
        public dynamic consultaUsuario(String nombreUsuario)
        {
            LectArchivo lectura1 = new LectArchivo();

            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            Usuario usuario1 = dc.Usuario.First(usua => usua.UsuarioID.Equals(nombreUsuario));
            return usuario1;
        }

        public void actualizarUsuario(string nombreUsuario, string correoElectronico, string nombreCompleto, string contraseña, Boolean bloqueado, int tipoUsuario)
        {
            LectArchivo lectura1 = new LectArchivo();

            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);


            Usuario usuario1 = dc.Usuario.First(usua => usua.UsuarioID.Equals(nombreUsuario));
            if (usuario1 == null)
            {
                throw new Exception("No se encontroe al usuario");
            }
            else
            {
                if (nombreUsuario != null && nombreUsuario != "")
                {
                    usuario1.DescUsuario = nombreUsuario;
                }
                else
                {
                    throw new Exception("Error: El nombre de usuario no es válido.");
                }
                if (correoElectronico != null && correoElectronico != "")
                {
                    usuario1.CorreoElectronico = correoElectronico;
                }
                else
                {
                    throw new Exception("Error: El correo electronico no es válido.");
                }
                if (contraseña != null && contraseña != "")
                {
                    usuario1.Contraseña = contraseña;
                }
                else
                {
                    throw new Exception("Error: La contraseña no es válido.");
                }

                if (nombreCompleto != null && nombreCompleto != "")
                {
                    usuario1.NombreCompleto = nombreCompleto;
                }
                else
                {
                    throw new Exception("Error: La contraseña no es válido.");
                }


                if (comprobarCorreo(correoElectronico) == true)
                {
                    usuario1.CorreoElectronico = correoElectronico;
                }
                else
                {
                    throw new Exception("Error: Correo no válido.");
                }

                if (bloqueado == true || bloqueado == true)
                {
                    usuario1.Bloqueado = bloqueado;
                }
                else
                {
                    throw new Exception("Error: El valor de bloqueado no valido no válido.");
                }

                if (tipoUsuario >= 0 || tipoUsuario <= 3 && tipoUsuario != null)
                {
                    usuario1.TipoUsuarioID = Convert.ToInt16(tipoUsuario);
                }
                else
                {
                    throw new Exception("Error: El valor de tipo de usuario es no valido no válido.");
                }
                dc.SubmitChanges();
                //MessageBox.Show("Se actualizó correctamente"); AQUI PUEDE VER UN MENSAJE
                dc.Connection.Close();

            }

        }


        public Boolean esNumero(object objeto)
        {
            Boolean esNumero;
            int retNumero;
            esNumero = int.TryParse(Convert.ToString(objeto), out retNumero);
            return esNumero;
        }

        public Boolean comprobarCorreo(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
