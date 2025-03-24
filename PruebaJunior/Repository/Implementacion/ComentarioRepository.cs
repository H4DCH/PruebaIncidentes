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
    public class ComentarioRepository : Repository<Comentario>, IComentarioRepository
    {
        private readonly Context _context;

        public ComentarioRepository(Context context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo.");
        }

        /// Obtiene los comentarios asociados a un incidente específico, ordenados por fecha de creación descendente.
        public async Task<List<Comentario>> ObetenerComentarios(int Id)
        {
            try
            {
                // Validar que el ID sea válido (mayor que 0)
                if (Id <= 0)
                {
                    throw new ArgumentException("El ID debe ser un valor positivo.", nameof(Id));
                }

                // Obtener los comentarios asociados al incidente, ordenados por fecha de creación descendente
                var comentarios = await _context.Comentarios
                    .Where(c => c.IncidenteId == Id)
                    .OrderByDescending(c => c.FechaCreacion)
                    .ToListAsync();

                return comentarios;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al obtener comentarios para el incidente con ID {Id}: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener los comentarios.", ex);
            }
        }
    }
}