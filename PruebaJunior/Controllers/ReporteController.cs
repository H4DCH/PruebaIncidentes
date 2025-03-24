using Microsoft.AspNetCore.Mvc;
using PruebaJunior.Repository.Implementacion;
using PruebaJunior.Repository.IRepository;
using System.Threading.Tasks;

namespace PruebaJunior.Controllers
{
    public class ReporteController : Controller
    {
        private readonly IIncidenteRepository _incidente;
        public ReporteController(IIncidenteRepository incidente)
        {
            _incidente = incidente;
        }

        public async Task<IActionResult> Index()
        {
            // Obtener estadísticas
            var estadisticasPorEstado = await _incidente.ObtenerIncidenciasPorEstado();
            var estadisticasPorPrioridad = await _incidente.ObtenerIncidenciasPorPrioridad();

            // Pasar los datos a la vista
            ViewBag.EstadisticasPorEstado = estadisticasPorEstado;
            ViewBag.EstadisticasPorPrioridad = estadisticasPorPrioridad;

            return View();
        }
    }
}
