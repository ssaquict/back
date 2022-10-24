using Microsoft.EntityFrameworkCore;
namespace web_api_empleado.Models{
    class conexion : DbContext{
        public conexion (DbContextOptions<conexion> options) : base (options){}

        public DbSet<empleados> empleados {get;set;}
    }

    class conectar{

        private const string cadenaConexion = "server=localhost;port=3306;database=db_empresa;userid=usr_empresa;pwd=Empres@123";
        public static conexion Create(){
            var constructor = new DbContextOptionsBuilder<conexion>();
            constructor.UseMySQL(cadenaConexion);
            var cn = new conexion (constructor.Options);
            return cn;
        }
    }
    
}