using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosCrud
{
    public class EmpleadoAG
    {
        public static int agregarEmpleado(Empleado empleado) 
        {
            int get = 0;
            
            using (SqlConnection conn = BDConect.getConn())
            {
                string query = "insert into empleado (nombre,edad,cargo) values('"+empleado.nombre+"',"+empleado.edad+" , '"+empleado.cargo+"')";
                SqlCommand comando = new SqlCommand(query,conn);
                get = comando.ExecuteNonQuery();
            }
            return get;
        }
        public static int BorrarEmpleado(int id)
        {
            int get = 0;

            using (SqlConnection conn = BDConect.getConn())
            {
                string query = "delete from empleado where id= " + id + " ";
                SqlCommand comando = new SqlCommand(query, conn);
                get = comando.ExecuteNonQuery();
            }
            return get;
        }


        public static List<Empleado> MostrarEmpleados()
        {
            List<Empleado> Lista = new List<Empleado>();
            using (SqlConnection conn = BDConect.getConn())
            {
                string query = "select *from empleado";
                SqlCommand comando = new SqlCommand(query, conn);


                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.id = reader.GetInt32(0);
                    empleado.nombre = reader.GetString(1);
                    empleado.edad = reader.GetInt32(2);
                    empleado.cargo = reader.GetString(3);
                    Lista.Add(empleado);

                }
                conn.Close();
                return Lista;
            }
        }



        public static int modificarEmpleado(Empleado empleado)
        {
            int get = 0;
            using (SqlConnection conn = BDConect.getConn())
            {
                string query = "update empleado set nombre='" + empleado.nombre +  "' , edad=" + empleado.edad + ", cargo='" + empleado.cargo+"' where id = " + empleado.id + " " ;
                SqlCommand comando = new SqlCommand(query, conn);

                get = comando.ExecuteNonQuery();
                conn.Close();
            }
            return get;
        }
    }


}
