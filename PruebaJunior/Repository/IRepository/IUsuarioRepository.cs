using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaJunior.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaJunior.Repository.IRepository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<List<Usuario>> ObtenerUsuarios();   
        Task<List<SelectListItem>> ObtenerSelectUsuarios();
    }
}
