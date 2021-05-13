using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication111.Repositories
{
    interface IRepository<T>
    {
        void Add(T item);
        void Delete(T item);
        IEnumerable<T> GetAll();
        Task Update(T item);
        Task<T> Find(string id);
    }
}
