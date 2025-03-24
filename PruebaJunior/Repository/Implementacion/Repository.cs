using Microsoft.EntityFrameworkCore;
using PruebaJunior.Data;
using PruebaJunior.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaJunior.Repository.Implementacion
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo.");
        }

        /// Propiedad protegida que proporciona acceso al DbSet correspondiente.
        protected DbSet<T> EntitySet => _context.Set<T>();


        /// Obtiene todas las entidades de tipo T.
        public async Task<List<T>> ObtenerTodos()
        {
            try
            {
                return await EntitySet.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al obtener todas las entidades: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener los datos.", ex);
            }
        }

        /// Elimina una entidad por su ID.
        public async Task Eliminar(int id)
        {
            try
            {
                // Validar que el ID sea válido (mayor que 0)
                if (id <= 0)
                {
                    throw new ArgumentException("El ID debe ser un valor positivo.", nameof(id));
                }

                var entidad = await EntitySet.FindAsync(id);

                if (entidad == null)
                {
                    throw new KeyNotFoundException($"No se encontró la entidad con ID {id}.");
                }

                EntitySet.Remove(entidad);
                await Guardar();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al eliminar entidad con ID {id}: {ex.Message}");
                throw new Exception("Ocurrió un error al eliminar la entidad.", ex);
            }
        }

        /// Obtiene una entidad por su ID.
        public async Task<T> ObtenerXId(int id)
        {
            try
            {
                // Validar que el ID sea válido (mayor que 0)
                if (id <= 0)
                {
                    throw new ArgumentException("El ID debe ser un valor positivo.", nameof(id));
                }

                // Buscar la entidad de manera asíncrona
                var entidad = await EntitySet.FindAsync(id);

                // Verificar si la entidad existe
                if (entidad == null)
                {
                    throw new KeyNotFoundException($"No se encontró la entidad con ID {id}.");
                }

                return entidad;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al obtener entidad con ID {id}: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener la entidad.", ex);
            }
        }

        /// Crea una nueva entidad.
        public async Task Crear(T modelo)
        {
            try
            {
                if (modelo == null)
                {
                    throw new ArgumentNullException(nameof(modelo), "El modelo no puede ser nulo.");
                }

                await EntitySet.AddAsync(modelo);
                await Guardar();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al crear entidad: {ex.Message}");
                throw new Exception("Ocurrió un error al crear la entidad.", ex);
            }
        }

        /// Guarda los cambios en la base de datos.
        public async Task Guardar()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al guardar cambios en la base de datos: {ex.Message}");
                throw new Exception("Ocurrió un error al guardar los cambios.", ex);
            }
        }

        /// Actualiza una entidad existente.
        public async Task Actualizar(T modelo)
        {
            try
            {
                if (modelo == null)
                {
                    throw new ArgumentNullException(nameof(modelo), "El modelo no puede ser nulo.");
                }

                EntitySet.Update(modelo);
                await Guardar();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al actualizar entidad: {ex.Message}");
                throw new Exception("Ocurrió un error al actualizar la entidad.", ex);
            }
        }
    }
}