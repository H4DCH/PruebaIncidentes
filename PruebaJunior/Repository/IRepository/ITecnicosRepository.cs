using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaJunior.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaJunior.Repository.IRepository
{
    public interface ITecnicosRepository : IRepository<Tecnico>
    {
        Task<List<Tecnico>> ObtenerTecnicos();
        Task<List<SelectListItem>> ObtenerSelectListItem();
    }
}
