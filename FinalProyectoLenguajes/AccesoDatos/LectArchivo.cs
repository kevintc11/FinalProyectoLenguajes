using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    class LectArchivo
    {

        public SqlConnectionStringBuilder leerServer1()
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "<server>.database.windows.net";
            builder.UserID = "<username>";
            builder.Password = "<password>";
            builder.InitialCatalog = "<database>";

            return builder;
        }

    }
}
