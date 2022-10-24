using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using web_api_empleado.Models;
namespace web_api_empleado.Controllers{

    [Route("api/[Controller]")]
    public class empleadosController : Controller{
       
        private conexion dbConexion;
        public empleadosController(){
            dbConexion = conectar.Create();
        }

        [HttpGet]
        public ActionResult Get(){
            return Ok(dbConexion.empleados.ToArray());
        
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id){
            //var Clientes = dbConexion.clientes.SingleOrDefault(a => a.idclientes == id);
            var Empleados = await dbConexion.empleados.FindAsync(id);
            if(Empleados !=null){
                return Ok(Empleados);
            
            } else{
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] empleados Empleados){
            if(ModelState.IsValid){
                dbConexion.empleados.Add(Empleados);
                //dbConexion.SaveChanges();
                await dbConexion.SaveChangesAsync();
                return Ok(Empleados);
            
            }else{
                return NotFound();
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] empleados Empleados){
            var v_empleados = dbConexion.empleados.SingleOrDefault(a => a.idEmpleados == Empleados.idEmpleados);
            if(v_empleados != null && ModelState.IsValid){
                dbConexion.Entry(v_empleados).CurrentValues.SetValues(Empleados);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }else{
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            var Empleados = dbConexion.empleados.SingleOrDefault(a => a.idEmpleados == id);
            if (Empleados != null){
                dbConexion.empleados.Remove(Empleados);
                await dbConexion.SaveChangesAsync();
                return Ok();

            } else{
                return NotFound();
            }
        }
    }
}
