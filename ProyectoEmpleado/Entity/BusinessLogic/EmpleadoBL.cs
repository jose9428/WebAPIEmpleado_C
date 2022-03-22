using Entity.BusinessEntity;
using Entity.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BusinessLogic
{
    public class EmpleadoBL
    {
        public List<Empleado> ListarTodosBL()
        {
            return new EmpleadoDA().ListarTodosDA();
        }

        public int AgregarBL(Empleado e)
        {
            return new EmpleadoDA().AgregarDA(e);
        }
        public int ActualizarBL(Empleado e)
        {
            return new EmpleadoDA().ActualizarDA(e);
        }
        public Empleado BuscarPorIdBL(int idEmp)
        {
            return new EmpleadoDA().BuscarPorIdDA(idEmp);
        }

        public int EliminarPorIdBL(int idEmp)
        {
            return new EmpleadoDA().EliminarPorIdDA(idEmp);
        }
    }
}
