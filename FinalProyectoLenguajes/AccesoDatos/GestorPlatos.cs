using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AccesoDatos
{
    public class GestorPlatos
    {

        public void insertarPedidoXPlato(int cantidadPlato, int platoID, int pedidoID)
        {

            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            Pedido_X_Plato pedido_X_Plato = new Pedido_X_Plato();
            pedido_X_Plato.CantidadPlato = Convert.ToInt16(cantidadPlato);
            pedido_X_Plato.PlatoID = Convert.ToInt16(platoID);
            pedido_X_Plato.PedidoID = Convert.ToInt16(pedidoID);
            dc.Pedido_X_Plato.InsertOnSubmit(pedido_X_Plato);
            dc.SubmitChanges();
            dc.Connection.Close();
        }

        public dynamic listPlatosActivos()
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            try
            {

                var platos = (from plato in dc.Plato
                              where plato.Estado == true
                              where plato.ActivoSN == true
                              select new { plato.PlatoID, plato.Nombre, plato.Precio }).ToList();

                return platos;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public dynamic buscarPlato(int platoID)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            try
            {
                if (verificarPlato(platoID))
                {
                    var platoa = (from plato in dc.Plato
                                  where plato.PlatoID == platoID && plato.ActivoSN == true
                                  select plato).Single();
                    //Plato plato1 = dc.Plato.First(pla => pla.PlatoID.Equals(platoID));
                    return platoa;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public dynamic listPlatos()
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            try
            {
                var platoa = (from plato in dc.Plato
                              where plato.ActivoSN == true
                              select new
                              {
                                  plato.PlatoID,
                                  plato.Nombre,
                                  plato.Precio
                              }).ToList();
                    return platoa;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public dynamic buscarPlato2(int platoID)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            try
            {
                if (verificarPlato(platoID))
                {

                    var platoa = (from plato in dc.Plato
                                  where plato.PlatoID == platoID && plato.ActivoSN == true
                                  select plato);

                    //Plato plato1 = dc.Plato.First(pla => pla.PlatoID.Equals(platoID));
                    return platoa;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void modifInsertPlato(Boolean isAdd, int platoID, string nombre, string descPlato, int precio, int estado, byte[] foto, int activo)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            try
            {
                Plato platoNuevo;
                if (buscarPlato(platoID) == null && isAdd != true)
                {
                    throw new Exception("Plato no existe");
                }
                else
                {
                    if (nombre != null || nombre != "")
                    {

                        if (isAdd)
                        {
                            platoNuevo = new Plato();
                            platoNuevo.Nombre = nombre;
                        }
                        else
                        {
                            platoNuevo = dc.Plato.First(pla => pla.PlatoID.Equals(platoID));
                            platoNuevo.Nombre = nombre;
                        }
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
                    if (foto != null && isAdd == false)
                    {
                        platoNuevo.Foto = foto;
                    }
                    else if(foto != null)
                    {
                        platoNuevo.Foto = foto;
                        
                    }else
                    {
                        throw new Exception("Otra vez aqui");
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
                    if (isAdd)
                    {
                        dc.Plato.InsertOnSubmit(platoNuevo);
                        dc.SubmitChanges();
                    }
                    else
                    {
                        dc.SubmitChanges();
                    }
                    dc.Connection.Close();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean verificarPlato(int platoID)
        {
         
                LectArchivo lectura1 = new LectArchivo();
                SqlConnectionStringBuilder conect = lectura1.leerServer1();
                SqlConnection conexion = new SqlConnection(conect.ConnectionString);
                DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            try
            {
                Plato plato1 = dc.Plato.First(pla => pla.PlatoID.Equals(platoID));
                if (plato1 != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
       
        }

        public void eliminarPlato(int platoID)
        {

            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            if (verificarPlato(platoID))
            {
                var plato1 = (from plato in dc.Plato
                              where plato.PlatoID == platoID && plato.ActivoSN == true
                              select plato).Single();
                if (plato1.DescPlato != "")
                {
                    Plato platoNuevo = plato1;
                    //Plato plato1 = dc.Plato.First(pla => pla.PlatoID.Equals(platoID));
                    platoNuevo.ActivoSN = false;
                    dc.SubmitChanges();
                    dc.Connection.Close();
                }
            }
            else
            {
                throw new Exception("Plato no existe");
            }

        }

        public dynamic buscarPlatoFiltro(string nombrePlato)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            try
            {
                if (verificarPlatoNombre(nombrePlato))
                {

                    var platoa = (from plato in dc.Plato
                                  where plato.Nombre.Contains(nombrePlato) && plato.ActivoSN == true
                                  select new
                                  {
                                      plato.PlatoID,
                                      plato.Nombre,
                                      plato.Precio
                                  }).ToList();
                    return platoa;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Boolean verificarPlatoNombre(string nombrePlato)
        {

            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            try
            {
                Plato plato1 = dc.Plato.First(pla => pla.Nombre.Contains(nombrePlato));
                if (plato1 != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public byte[] mostrarImagen(int platoID)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            if (buscarPlato(platoID) != null)
            {
                var platos = (from plato in dc.Plato
                              where plato.PlatoID == platoID
                              select plato).Single();
                return platos.Foto;
            }
            return null;
        }
    }
}
