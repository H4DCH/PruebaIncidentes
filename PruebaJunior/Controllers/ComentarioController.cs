using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaJunior.Models;
using PruebaJunior.Models.DTO;
using PruebaJunior.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaJunior.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioRepository _comentario;
        private readonly IMapper _mapper;

        public ComentarioController(IComentarioRepository comentario, IMapper mapper)
        {
            _comentario = comentario;
            _mapper = mapper;
        }

        /// Obtiene los comentarios asociados a un incidente específico.
        [HttpGet]
        public async Task<ActionResult> ObtenerComentarios(int Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest("El ID del incidente no es válido.");
                }

                // Obtener los comentarios desde el repositorio
                var comentarios = await _comentario.ObetenerComentarios(Id);

                if (comentarios == null || comentarios.Count == 0)
                {
                    return Json(new { success = true, message = "No hay comentarios disponibles.", comentarios = new List<ComentarioDTO>() });
                }

                // Mapear los comentarios a DTOs para la respuesta
                var comentariosDTO = _mapper.Map<List<ComentarioDTO>>(comentarios);

                return Json(new { success = true, comentarios = comentariosDTO });
            }
            catch (Exception ex)
            {
                // Registrar el error y devolver una respuesta de error
                Console.Error.WriteLine($"Error al obtener comentarios: {ex.Message}");
                return StatusCode(500, "Ocurrió un error al obtener los comentarios.");
            }
        }

        /// Agrega un nuevo comentario asociado a un incidente.
        [HttpPost]
        public async Task<ActionResult> AgregarComentario(ComentarioDTO comentarioDTO)
        {
            try
            {
                if (comentarioDTO == null || string.IsNullOrWhiteSpace(comentarioDTO.Texto))
                {
                    return BadRequest("El texto del comentario es obligatorio.");
                }

                // Asignar la fecha actual al comentario
                comentarioDTO.FechaCreacion = DateTime.Now;

                // Mapear el DTO al modelo de entidad
                var comentarioNuevo = _mapper.Map<Comentario>(comentarioDTO);

                // Guardar el comentario en la base de datos
                await _comentario.Crear(comentarioNuevo);

                // Devolver una respuesta JSON con los datos del comentario creado
                return Json(new
                {
                    success = true,
                    comentarioNuevo = new
                    {
                        Texto = comentarioNuevo.Texto,
                        FechaCreacion = comentarioNuevo.FechaCreacion.ToString("yyyy-MM-ddTHH:mm:ss"), // ISO 8601
                        Id = comentarioNuevo.Id
                    }
                });
            }
            catch (Exception ex)
            {
                // Registrar el error y devolver una respuesta de error
                Console.Error.WriteLine($"Error al agregar comentario: {ex.Message}");
                return StatusCode(500, "Ocurrió un error al agregar el comentario.");
            }
        }
    }
}