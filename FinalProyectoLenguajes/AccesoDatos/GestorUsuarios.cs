using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class GestorUsuarios
    {
        public dynamic consultaUsuario(String nombreUsuario)
        {
            try
            {
                LectArchivo lectura1 = new LectArchivo();

                SqlConnectionStringBuilder conect = lectura1.leerServer1();
                SqlConnection conexion = new SqlConnection(conect.ConnectionString);
                DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
                //Usuario usuario1 = dc.Usuario.First(usua => usua.UsuarioID.Equals(nombreUsuario));
                var usuario1 = (from usuario in dc.Usuario
                                where usuario.DescUsuario.Equals(nombreUsuario)
                                where usuario.ActivoSN == true
                                select usuario).Single();
                return usuario1;
            }
            catch(Exception)
            {
                return null;  
            }
        }

        public dynamic consultaUsuarioLista(String nombreUsuario)
        {
            try
            {
                LectArchivo lectura1 = new LectArchivo();

                SqlConnectionStringBuilder conect = lectura1.leerServer1();
                SqlConnection conexion = new SqlConnection(conect.ConnectionString);
                DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
                //Usuario usuario1 = dc.Usuario.First(usua => usua.UsuarioID.Equals(nombreUsuario));
                var usuario1 = (from usuario in dc.Usuario
                                where (usuario.DescUsuario.Equals(nombreUsuario) && usuario.ActivoSN == true)
                                select usuario);
                return usuario1;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public void eliminarCliente(string nombreUsuario)
        {
            LectArchivo lectura1 = new LectArchivo();

            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            
            if (comprobarUsuario(nombreUsuario))
            {
                throw new Exception("El usuasario ya esta eliminado");
            }

            //Cliente cliente = dc.Cliente.First(clie => clie.Cedula.Equals(cedula));
            var usuario1 = (from usuario in dc.Usuario
                            where usuario.DescUsuario.Equals(nombreUsuario)
                            where usuario.ActivoSN == true
                            select usuario).Single();
          
            usuario1.ActivoSN = false;
            dc.SubmitChanges();
            dc.Connection.Close();
            
          
        }


        public Boolean comprobarUsuario(String nombreUsuario)
        {
            Usuario usuarioNuevo = (Usuario)consultaUsuario(nombreUsuario);
            if (usuarioNuevo == null)
            {
                return false;
            }
            return true;
        }

        public void insertarUsuario(string nombreUsuario, string correoElectronico, string nombreCompleto, string contraseña, int tipoUsuario, string direccion)
        {
            //try
            //{
                LectArchivo lectura1 = new LectArchivo();

                SqlConnectionStringBuilder conect = lectura1.leerServer1();
                SqlConnection conexion = new SqlConnection(conect.ConnectionString);
                DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
                Usuario usuario1 = new Usuario();

                if (comprobarUsuario(nombreUsuario))
                {
                    throw new Exception("El nombre de usuario ingresado ya existe, selecione otro");
                }

                if (nombreUsuario != null && nombreUsuario != "")
                {
                    usuario1.DescUsuario = nombreUsuario;
                }
                else
                {
                    throw new Exception("El nombre de usuario no puede estar vacío");
                }

                if (comprobarCorreo(correoElectronico) == true)
                {
                    usuario1.CorreoElectronico = correoElectronico;
                }
                else
                {
                    throw new Exception("Digite un correo válido");
                }


                if (nombreCompleto != null && nombreCompleto != "")
                {
                    usuario1.NombreCompleto = nombreCompleto;
                }
                else
                {
                    throw new Exception("Digite un nombre válido");
                }

                if (contraseña != null && contraseña != "")
                {
                    usuario1.Contraseña = contraseña;
                }
                else
                {
                    throw new Exception("Digite una contraseña válido");
                }

                if (direccion != null && direccion != "")
                {
                    usuario1.Direccion = direccion;
                }
                else
                {
                    throw new Exception("Digite una contraseña válido");
                }

                if (tipoUsuario >= 1 || tipoUsuario <= 3)
                {
                    usuario1.TipoUsuarioID = Convert.ToInt16(tipoUsuario);
                }
                else
                {
                    throw new Exception("Digite un tipo de usuario válido");
                }
                usuario1.Bloqueado = false;
                usuario1.ActivoSN = true;



                dc.Usuario.InsertOnSubmit(usuario1);
                dc.SubmitChanges();
                dc.Connection.Close();



            //}
            //catch (IOException ex)
            //{
             //   throw new Exception("Ocurrió un error, verifique la ruta de acceso a la base de datos.");
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}
        }




        public void actualizarUsuario(string nombreUsuario, string correoElectronico, string nombreCompleto, string contraseña, Boolean bloqueado, string direccion)
        {
            LectArchivo lectura1 = new LectArchivo();

            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);


            Usuario usuario1 = dc.Usuario.First(usua => usua.DescUsuario.Equals(nombreUsuario));
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

                if (direccion != null && direccion != "")
                {
                    usuario1.Direccion = direccion;
                }
                else
                {
                    throw new Exception("Error: La direccion no es válido.");
                }

                if (comprobarCorreo(correoElectronico) == true)
                {
                    usuario1.CorreoElectronico = correoElectronico;
                }
                else
                {
                    throw new Exception("Error: Correo no válido.");
                }

                if (bloqueado == true || bloqueado == false)
                {
                    usuario1.Bloqueado = bloqueado;
                }
                else
                {
                    new Exception("Error: El valor de bloqueado no valido no válido.");
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

        public Boolean iniciarSesión(string nickname, string password)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            Usuario usuarioConsulta = (Usuario)consultaUsuario(nickname);

            if (usuarioConsulta == null)
            {
                throw new Exception("Nombre de usuario incorrecto");
            }
            else
            {
                if (usuarioConsulta.Contraseña.Equals(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
