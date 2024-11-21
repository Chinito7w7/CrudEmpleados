using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosCrud
{
    public class BDConect
    {
        public static SqlConnection getConn()
        {
            SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=dbEmpleados;Data Source=DESKTOP-P536S10\\SQLEXPRESS");
            conn.Open();
            return conn;
        }
    }
}
