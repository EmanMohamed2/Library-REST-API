using Library.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByID(int id);
        Task<Response> Delete(T item);
        Task<Response> CreateAsync(T item);
        Task<Response> UpdateAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> Find(int id);

    }
}
