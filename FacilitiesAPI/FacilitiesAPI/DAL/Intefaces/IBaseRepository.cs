using FacilitiesAPI.Models;

namespace FacilitiesAPI.DAL.Intefaces
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task<T> Delete(int id);
    }
}
