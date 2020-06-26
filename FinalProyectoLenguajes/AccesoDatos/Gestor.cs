using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccesoDatos
{
    class Gestor
    {
        public Plato buscarPlato(string nombrePlato)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            Plato plato1 = dc.Plato.First(pla => pla.Nombre.Equals(nombrePlato));
            return plato1;
        }

        public void modificarPlato(int platoID, string nombre, string descPlato, int precio, int estado, string foto, int activo)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            try
            {
                Plato platoNuevo;
                if (nombre != null || nombre != "")
                {
                    platoNuevo = dc.Plato.First(pla => pla.Nombre.Equals(nombre));
                }
                else
                {
                    throw new Exception("Error: Nombre inválido");
                }
                if (descPlato != null || descPlato != "")
                {
                    platoNuevo.DescPlato = descPlato;
                }
                else
                {
                    throw new Exception("Error: Descripción del plato inválida");
                }
                if (precio > 0)
                {
                    platoNuevo.Precio = precio;
                }
                else
                {
                    throw new Exception("Error: Precio del producto inválido");
                }
                if (estado == 0 || estado == 1)
                {
                    if (estado == 1)
                    {
                        platoNuevo.Estado = true;
                    }
                    else
                    {
                        platoNuevo.Estado = false;
                    }
                }
                else
                {
                    throw new Exception("Error: El estado del producto es inválido");
                }
                if (activo == 1 || activo == 0)
                {
                    if (activo == 1)
                    {
                        platoNuevo.ActivoSN = true;
                    }
                    else
                    {
                        platoNuevo.ActivoSN = false;
                    }

                }
                else
                {
                    throw new Exception("Error: En activo");
                }
                dc.SubmitChanges();
                MessageBox.Show("El plato se ha modificado satisfactoriamente");
                dc.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }
    }
}
