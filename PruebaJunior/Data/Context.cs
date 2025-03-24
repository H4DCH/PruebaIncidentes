using Microsoft.EntityFrameworkCore;
using PruebaJunior.Models;

namespace PruebaJunior.Data
{
    public class Context : DbContext
    {
        /// Constructor que recibe las opciones de configuración del DbContext.
        public Context(DbContextOptions<Context> options) : base(options)
        {
            // El constructor recibe las opciones de configuración (por ejemplo, la cadena de conexión).
        }

        /// Representa la tabla de Incidentes en la base de datos.
        public DbSet<Incidente> Incidente { get; set; }


        /// Representa la tabla de Usuarios en la base de datos.
        public DbSet<Usuario> Usuarios { get; set; }

        /// Representa la tabla de Técnicos en la base de datos.
        public DbSet<Tecnico> Tecnicos { get; set; }

        /// Representa la tabla de Comentarios en la base de datos.
        public DbSet<Comentario> Comentarios { get; set; }


    }
}
