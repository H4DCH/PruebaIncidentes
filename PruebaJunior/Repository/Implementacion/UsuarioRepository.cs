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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly Context _context;

        public UsuarioRepository(Context context) : base(context)
        {
            _context = context;
        }

        /// Obtiene una lista de usuarios en formato SelectListItem para dropdowns.
        public async Task<List<SelectListItem>> ObtenerSelectUsuarios()
        {
            try
            {
                // Obtener todos los usuarios desde la base de datos
                var usuarios = await ObtenerUsuarios();

                if (usuarios == null || !usuarios.Any())
                {
                    return new List<SelectListItem>(); // Devolver una lista vacía si no hay usuarios
                }

                // Mapear los usuarios a SelectListItem
                return usuarios.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Nombre
                }).ToList();
            }
            catch (Exception ex)
            {
                // Registrar el error y lanzar una excepción para que el controlador maneje el error
                Console.Error.WriteLine($"Error al obtener usuarios para SelectList: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener la lista de usuarios.");
            }
        }

        /// Obtiene todos los usuarios registrados en la base de datos.
        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            try
            {
                // Obtener todos los usuarios desde la base de datos
                var lista = await _context.Usuarios.ToListAsync();

                if (lista == null || !lista.Any())
                {
                    return new List<Usuario>(); // Devolver una lista vacía si no hay usuarios
                }

                return lista;
            }
            catch (Exception ex)
            {
                // Registrar el error y lanzar una excepción para que el controlador maneje el error
                Console.Error.WriteLine($"Error al obtener usuarios: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener los usuarios.");
            }
        }
    }
}