using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class LectArchivo
    {

        public SqlConnectionStringBuilder leerServer1()
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "proyectolenguajesfinal.database.windows.net";
            builder.UserID = "nacho";
            builder.Password = "Ignacio123";
            builder.InitialCatalog = "dbproyectolenguajes";

            return builder;
        }

    }
}
