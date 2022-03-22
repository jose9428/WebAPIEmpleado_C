using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BusinessEntity
{
    public class Empleado
    {
        public int id_empleado { get; set; }
        public string nombres { get; set; }
        public string ape_paterno { get; set; }
        public string ape_materno { get; set; }
        public string genero { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public DateTime fecha_registro { get; set; }
        public string correo { get; set; }
        public double sueldo { get; set; }

    }
}
