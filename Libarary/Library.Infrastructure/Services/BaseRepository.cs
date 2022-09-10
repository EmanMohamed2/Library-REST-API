using Libarary.Interface;
using Library.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Services
{
    public class BaseRepository<T> : IBaseRepositoy<T> where T : class
    {
        private readonly WorkingDB _Context;
        public BaseRepository(WorkingDB Context)
        {
            _Context = Context;
        }
        public async Task<T> GetById(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }
    }
}
