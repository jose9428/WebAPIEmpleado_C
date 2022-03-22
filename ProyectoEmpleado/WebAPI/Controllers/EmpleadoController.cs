using Entity.BusinessEntity;
using Entity.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        [HttpGet]
        [Route("listar")]
        public List<Empleado> ListarTodos()
        {
            List<Empleado> lista = new List<Empleado>();
            try
            {
                lista = new EmpleadoBL().ListarTodosBL();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return lista;
        }

        [HttpPost]
        [Route("guardar")]
        public IActionResult Agregar(Empleado obj)
        {
            return Ok(new EmpleadoBL().AgregarBL(obj));
        }

        [HttpPut]
        [Route("actualizar")]
        public IActionResult Actualizar(Empleado obj)
        {
            return Ok(new EmpleadoBL().ActualizarBL(obj));
        }


        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(new EmpleadoBL().BuscarPorIdBL(id));
        }


        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarPorId(int id)
        {
            return Ok(new EmpleadoBL().EliminarPorIdBL(id));
        }
    }
}
