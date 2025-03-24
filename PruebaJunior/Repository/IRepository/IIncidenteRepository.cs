using PruebaJunior.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaJunior.Repository.IRepository
{
    public interface IIncidenteRepository : IRepository<Incidente>
    {
        Task<List<Incidente>> ObtenerIncidentes();
        Task<Incidente> ObtenerIncidenteXId(int Id);
        Task<Dictionary<string, int>> ObtenerIncidenciasPorEstado();
        Task<Dictionary<string, int>> ObtenerIncidenciasPorPrioridad();
    }
}
