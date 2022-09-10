using Library.Core.DTO;
using Library.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.EF.Services
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDBContext _context;
        public BaseRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Response> CreateAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            _context.SaveChanges();
            return new Response
            {
                Status = "Success",
                Message = $"{typeof(T)} has been added successfully"
            };
        }
        public async Task<T> GetByID(int id)
        {
          var data= await _context.Set<T>().FindAsync(id);
          if(data==null)
                return null;
          return data;
        }
        public async Task<Response> Delete(T item)
        {
            var data = _context.Set<T>().Remove(item);
            _context.SaveChanges();
            if (data == null)
                return new Response { Status = "Fail", Message = $"This {item} is not deleted" };
            return new Response { Status="Success",Message=$"This {item} is deleted"};
        }
        public async Task<Response> UpdateAsync(T item)
        {
            var data = _context.Set<T>().Update(item);
            _context.SaveChanges();
            if (data == null)
                return new Response { Status = "Fail", Message = $"This {item} is not Updated" };
            return new Response { Status = "Success", Message = $"This {item} is Updated" };
        }
        public async Task<IEnumerable<T>> GetAllAsync() 
        {
            var listOfItems = await _context.Set<T>().ToListAsync();
            return listOfItems;

        }
        public async Task<T> Find(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
       
    }
}
