using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.AbstractRepo
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T t);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindByIdAsync(Guid id);
        T Update(T t);
        void Remove(Guid id);
    }
}
