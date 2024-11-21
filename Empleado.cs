using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosCrud
{
    public class Empleado
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string cargo { get; set; }

        public Empleado () { } 
        public Empleado (int id, string nombre, int edad, string cargo)
        {
            this.id = id;
            this.nombre = nombre;
            this.edad = edad;
            this.cargo = cargo;
        }
    }
}
