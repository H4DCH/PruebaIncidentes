using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class TecnicoRepository : Repository<Tecnico>, ITecnicosRepository
    {
        private readonly Context _context;

        public TecnicoRepository(Context context) : base(context)
        {
            _context = context;
        }

        /// Obtiene una lista de técnicos en formato SelectListItem para dropdowns.
        public async Task<List<SelectListItem>> ObtenerSelectListItem()
        {
            try
            {
                // Obtener todos los técnicos desde la base de datos
                var tecnicos = await ObtenerTecnicos();

                if (tecnicos == null || !tecnicos.Any())
                {
                    return new List<SelectListItem>(); // Devolver una lista vacía si no hay técnicos
                }

                // Mapear los técnicos a SelectListItem
                return tecnicos.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.NombreTecnico
                }).ToList();
            }
            catch (Exception ex)
            {
                // Registrar el error y lanzar una excepción para que el controlador maneje el error
                Console.Error.WriteLine($"Error al obtener técnicos para SelectList: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener la lista de técnicos.");
            }
        }

        /// Obtiene todos los técnicos registrados en la base de datos.
        public async Task<List<Tecnico>> ObtenerTecnicos()
        {
            try
            {
                // Obtener todos los técnicos desde la base de datos
                var lista = await _context.Tecnicos.ToListAsync();

                if (lista == null || !lista.Any())
                {
                    return new List<Tecnico>(); // Devolver una lista vacía si no hay técnicos
                }

                return lista;
            }
            catch (Exception ex)
            {
                // Registrar el error y lanzar una excepción para que el controlador maneje el error
                Console.Error.WriteLine($"Error al obtener técnicos: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener los técnicos.");
            }
        }
    }
}