using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KMA.Repository.Interfaces
{
    public interface IRepository<T, K> where T : class
    {
        public Task<ICollection<T>> GetAllAsync();
        public Task<T> GetAsync(K key);
        public Task<T> FindAsync(params K[] key);
        public Task<ICollection<T>> FindAllAsync(params K[] key);
        public Task<T> AddAsync(T newModel, params K[] key);
        public Task<T> UpdateAsync(T updated, params K[] key);
        public Task<int> DeleteAsync(T t);
        public Task<int> CountAsync();
    }
}
