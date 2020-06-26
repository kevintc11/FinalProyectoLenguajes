using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccesoDatos
{
    class Gestor
    {
        public void buscarPlato(string plato)
        {
            //LecturaArchivos lectura = new LecturaArchivos();
            //SqlConnection conexion = new SqlConnection(lectura.leerServer());
            //DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            //var clientes = from cliente in dc.Cliente
            //               where cliente.indicActivoCliente == 1
            //               select cliente;
            LectArchivo lectura1 = new LectArchivo();

            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
        }

    }
}
