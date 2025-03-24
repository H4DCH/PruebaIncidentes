using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaJunior.Repository.IRepository
{
    public interface IRepository<T> where T : class 
    {
        Task<List<T>> ObtenerTodos();
        Task<T> ObtenerXId(int id);
        Task Eliminar(int id);
        Task Crear(T modelo);
        Task Actualizar (T modelo); 
    }
}
