using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.RepositoryLayer.Contracts
{
    public interface IGenericRepository<T, K> where T : class
    {
        Task<T> GetAsync(K id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task<bool> Exists(K id);
        Task DeleteAsync(K id);
        Task UpdateAsync(T entity);
    }
}
