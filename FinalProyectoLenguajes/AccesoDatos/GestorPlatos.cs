﻿using System;
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
        public dynamic buscarPlato(int platoID)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);

            if (verificarPlato(platoID))
            {
                var platoa = from plato in dc.Plato
                             where plato.PlatoID == platoID
                             select plato;

                //Plato plato1 = dc.Plato.First(pla => pla.PlatoID.Equals(platoID));
                return platoa;
            }
            else
            {
                return null;
            }
        }

        public void modifInsertPlato(Boolean isAdd, int platoID, string nombre, string descPlato, int precio, int estado, string foto, int activo)
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

                    if (isAdd)
                    {
                        platoNuevo = new Plato();
                        platoNuevo.Nombre = nombre;
                    }
                    else
                    {
                        platoNuevo = dc.Plato.First(pla => pla.Nombre.Equals(nombre));
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


    }
}
