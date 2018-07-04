using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);

        Task<T> GetByIdAsync(int id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        void DeleteAsync(T entity);

        Task<int> CountAsync(Func<T, bool> predicate);

        Task<bool> AnyAsync(Func<T, bool> predicate);

        Task<bool> AnyAsync();
    }
}
