using Microsoft.EntityFrameworkCore;
using PruebaJunior.Data;
using PruebaJunior.Models;
using PruebaJunior.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaJunior.Repository.Implementacion
{
    public class IncidenteRepository : Repository<Incidente>, IIncidenteRepository
    {
        private readonly Context _context;

        public IncidenteRepository(Context context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo.");

        }

         /// Obtiene un diccionario que representa el número de incidencias agrupadas por estado.
        public async Task<Dictionary<string, int>> ObtenerIncidenciasPorEstado()
        {
            // Consulta la base de datos para agrupar las incidencias por su campo "Estado"
            return await _context.Incidente
                .GroupBy(i => i.Estado) // Agrupa las incidencias por el campo "Estado"
                .Select(g => new
                {
                    Estado = g.Key.ToString(), // Convierte la clave del grupo (estado) a string
                    Cantidad = g.Count()       // Cuenta cuántas incidencias hay en cada grupo
                })
                .ToDictionaryAsync(x => x.Estado, x => x.Cantidad); // Convierte el resultado en un diccionario
        }

  
        /// Obtiene un diccionario que representa el número de incidencias agrupadas por prioridad.
        public async Task<Dictionary<string, int>> ObtenerIncidenciasPorPrioridad()
        {
            // Consulta la base de datos para agrupar las incidencias por su campo "Prioridad"
            return await _context.Incidente
                .GroupBy(i => i.Prioridad) // Agrupa las incidencias por el campo "Prioridad"
                .Select(g => new
                {
                    Prioridad = g.Key.ToString(), // Convierte la clave del grupo (prioridad) a string
                    Cantidad = g.Count()         // Cuenta cuántas incidencias hay en cada grupo
                })
                .ToDictionaryAsync(x => x.Prioridad, x => x.Cantidad); // Convierte el resultado en un diccionario
        }

        /// Obtiene todos los incidentes con sus relaciones (Técnico, Usuario y Comentarios).
        public async Task<List<Incidente>> ObtenerIncidentes()
        {
            try
            {
                // Incluir las relaciones necesarias: Técnico, Usuario
                var incidentes = await _context.Incidente
                    .Include(t => t.Tecnico)
                    .Include(u => u.Usuario)
                    .ToListAsync();

                return incidentes;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al obtener incidentes: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener la lista de incidentes.", ex);
            }
        }

        /// Obtiene un incidente por su ID, incluyendo sus relaciones (Técnico, Usuario y Comentarios).
        public async Task<Incidente> ObtenerIncidenteXId(int Id)
        {
            try
            {
                // Validar que el ID sea válido (mayor que 0)
                if (Id <= 0)
                {
                    throw new ArgumentException("El ID debe ser un valor positivo.", nameof(Id));
                }

                // Incluir las relaciones necesarias: Técnico, Usuario, Comentarios
                var incidente = await _context.Incidente
                    .Include(t => t.Tecnico)
                    .Include(u => u.Usuario)
                    .Include(c => c.Comentarios)
                    .FirstOrDefaultAsync(i => i.Id == Id);

                // Verificar si el incidente existe
                if (incidente == null)
                {
                    throw new KeyNotFoundException($"No se encontró el incidente con ID {Id}.");
                }

                return incidente;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al obtener incidente con ID {Id}: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener el incidente.", ex);
            }
        }
    }
}