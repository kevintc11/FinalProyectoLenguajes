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
        public Plato buscarPlato(string nombrePlato)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            Plato plato1 = dc.Plato.First(pla => pla.Nombre.Equals(nombrePlato));
            return plato1;
        }

        public void modificarPlato(int platoID, string nombre, string descPlato, int precio, int estado, string foto)
        {
            LectArchivo lectura1 = new LectArchivo();
            SqlConnectionStringBuilder conect = lectura1.leerServer1();
            SqlConnection conexion = new SqlConnection(conect.ConnectionString);
            DataClasses1DataContext dc = new DataClasses1DataContext(conexion);
            try
            {
                if (nombre != null || nombre != "")
                {

                }
            }
        }

    }
}
