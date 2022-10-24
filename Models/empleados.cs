using System.ComponentModel.DataAnnotations;
namespace web_api_empleado.Models{
    public class empleados{
        [Key]
        public int idEmpleados {get;set;}
        public string Nombre {get;set;}
        public string Apellido {get;set;}    
        public string Direccion {get;set;}
        public string Telefono {get;set;}
        public string idPuesto {get;set;}
        public string DPI {get;set;}
        public string FechaNacimiento {get;set;}
        public string FechaIngresoRegistro {get;set;}
    }
    
}
