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
            builder.DataSource = "SQL5053.site4now.net";
            builder.UserID = "DB_A64025_BaseLenguajes_admin";
            builder.Password = "K.tc1218";
            builder.InitialCatalog = "DB_A64025_BaseLenguajes";

            return builder;
        }
    }
}
