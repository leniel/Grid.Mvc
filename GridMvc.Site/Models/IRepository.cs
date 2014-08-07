using System.Linq;

namespace GridMvc.Site.Models
{
    public interface IRepository<out T>
    {
        IOrderedQueryable<T> GetAll();
        T GetById(object id);
    }
}