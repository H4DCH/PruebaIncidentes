using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaJunior.Data;
using PruebaJunior.Models;
using PruebaJunior.Models.DTO;
using PruebaJunior.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaJunior.Controllers
{
    public class IncidentesController : Controller
    {
        private readonly IIncidenteRepository _incidente;
        private readonly ITecnicosRepository _tecnico;
        private readonly IUsuarioRepository _usuario;
        private readonly IMapper _mapper;
        private readonly Context _context;

        public IncidentesController(
            IIncidenteRepository incidente,
            IMapper mapper,
            ITecnicosRepository tecnico,
            IUsuarioRepository usuario,
            Context context)
        {
            _incidente = incidente;
            _mapper = mapper;
            _tecnico = tecnico;
            _usuario = usuario;
            _context = context;
        }

        /// Muestra la lista de incidentes en la vista "Inicio".
        public async Task<ActionResult> Inicio()
        {
            try
            {
                // Obtener todos los incidentes desde el repositorio
                var incidentes = await _incidente.ObtenerIncidentes();

                // Mapear los incidentes a DTOs para la vista
                var incidentesDTO = _mapper.Map<List<IncidenteDTO>>(incidentes);

                return View(incidentesDTO);
            }
            catch (Exception ex)
            {
                // Registrar el error en un servicio de logs o consola
                Console.Error.WriteLine($"Error al cargar incidentes: {ex.Message}");
                return StatusCode(500, "Ocurrió un error al cargar los incidentes.");
            }
        }

        /// Muestra los detalles de un incidente específico.

        public async Task<ActionResult> DetalleIncidente(int Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return RedirectToAction("Inicio");
                }

                // Obtener el incidente por ID desde el repositorio
                var incidente = await _incidente.ObtenerIncidenteXId(Id);

                if (incidente == null)
                {
                    return NotFound();
                }

                // Mapear el incidente a un DTO para la vista
                var incidenteDTO = _mapper.Map<IncidenteDTO>(incidente);

                return View(incidenteDTO);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al cargar detalles del incidente: {ex.Message}");
                return StatusCode(500, "Ocurrió un error al cargar los detalles del incidente.");
            }
        }

        /// Muestra la vista para registrar un nuevo incidente.
        public async Task<ActionResult> Registrar()
        {
            try
            {
                // Obtener listas de técnicos y usuarios para los dropdowns
                var tecnicos = await _tecnico.ObtenerSelectListItem();
                ViewBag.Tecnicos = tecnicos;

                var usuarios = await _usuario.ObtenerSelectUsuarios();
                ViewBag.Usuarios = usuarios;

                return View();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al cargar datos para registrar incidente: {ex.Message}");
                return StatusCode(500, "Ocurrió un error al cargar los datos necesarios para registrar un incidente.");
            }
        }

        /// Registra un nuevo incidente en la base de datos.
        [HttpPost]
        public async Task<ActionResult> Registrar(CrearIncidenteDTO incidenteDTO)
        {
            if (!ModelState.IsValid)
            {
                // Si el modelo no es válido, volver a mostrar la vista con errores
                return View(incidenteDTO);
            }

            try
            {
                // Mapear el DTO al modelo de entidad
                var incidente = _mapper.Map<Incidente>(incidenteDTO);

                // Guardar el incidente en la base de datos
                await _incidente.Crear(incidente);

                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                // Registrar el error y mostrar un mensaje al usuario
                Console.Error.WriteLine($"Error al registrar incidente: {ex.Message}");
                ModelState.AddModelError("", "Ocurrió un error al guardar el incidente. Por favor, inténtalo de nuevo.");
                return View(incidenteDTO);
            }
        }

        /// Muestra la vista para editar un incidente existente.
        [HttpGet]
        public async Task<ActionResult> Editar(int Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return RedirectToAction("Inicio");
                }

                // Obtener el incidente por ID desde el repositorio
                var incidente = await _incidente.ObtenerXId(Id);

                if (incidente == null)
                {
                    return NotFound();
                }

                // Mapear el incidente a un DTO para la vista
                var incidenteDTO = _mapper.Map<ActualizarIncidenteDTO>(incidente);

                // Configurar las listas para los dropdowns
                var prioridades = new List<SelectListItem>
                {
                    new SelectListItem { Value = "0", Text = "Baja" },
                    new SelectListItem { Value = "1", Text = "Media" },
                    new SelectListItem { Value = "2", Text = "Alta" },
                    new SelectListItem { Value = "3", Text = "Crítica" }
                };

                ViewBag.Prioridades = new SelectList(prioridades, "Value", "Text");

                var estados = new List<SelectListItem>
                {
                    new SelectListItem { Value = "0", Text = "Abierto" },
                    new SelectListItem { Value = "1", Text = "EnProgreso" },
                    new SelectListItem { Value = "2", Text = "Resuelto" },
                    new SelectListItem { Value = "3", Text = "Cerrado" }
                };

                ViewBag.Estados = new SelectList(estados, "Value", "Text");

                var tecnicos = await _tecnico.ObtenerSelectListItem();
                ViewBag.Tecnicos = tecnicos;

                var usuarios = await _usuario.ObtenerSelectUsuarios();
                ViewBag.Usuarios = usuarios;

                return View(incidenteDTO);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al cargar datos para editar incidente: {ex.Message}");
                return StatusCode(500, "Ocurrió un error al cargar los datos necesarios para editar el incidente.");
            }
        }

        /// Actualiza un incidente existente en la base de datos.
        [HttpPost]
        public async Task<ActionResult> Editar(ActualizarIncidenteDTO incidenteDTO)
        {
            if (!ModelState.IsValid)
            {
                // Si el modelo no es válido, volver a mostrar la vista con errores
                return View(incidenteDTO);
            }

            try
            {
                // Verificar que el incidente exista en la base de datos
                var incidente = await _incidente.ObtenerXId(incidenteDTO.Id);

                if (incidente == null)
                {
                    return NotFound();
                }

                // Mapear el DTO al modelo de entidad existente
                _mapper.Map(incidenteDTO, incidente);

                // Actualizar el incidente en la base de datos
                await _incidente.Actualizar(incidente);

                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                // Registrar el error y mostrar un mensaje al usuario
                Console.Error.WriteLine($"Error al actualizar incidente: {ex.Message}");
                ModelState.AddModelError("", "Ocurrió un error al actualizar el incidente. Por favor, inténtalo de nuevo.");
                return View(incidenteDTO);
            }
        }

        /// Elimina un incidente existente de la base de datos.
        [HttpPost]
        public async Task<ActionResult> Eliminar(int Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return RedirectToAction("Inicio");
                }

                // Verificar que el incidente exista en la base de datos
                var incidente = await _incidente.ObtenerXId(Id);

                if (incidente == null)
                {
                    return NotFound();
                }

                // Eliminar el incidente de la base de datos
                await _incidente.Eliminar(Id);

                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                // Registrar el error y devolver un código de estado HTTP 500
                Console.Error.WriteLine($"Error al eliminar incidente: {ex.Message}");
                return StatusCode(500, "Ocurrió un error al eliminar el incidente.");
            }
        }
    }

}
