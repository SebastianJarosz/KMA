using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Pickers.Interfaces
{
    public interface IPicker<T, K> where T : class
    {
        public Task<ICollection<T>> AsyncGetAllItems(K key);
        public Task<T> AsyncGetItem(K key);
    }
}
