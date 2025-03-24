using PruebaJunior.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaJunior.Repository.IRepository
{
    public interface IComentarioRepository : IRepository<Comentario>
    {
        Task<List<Comentario>> ObetenerComentarios(int Id);
    }
}
