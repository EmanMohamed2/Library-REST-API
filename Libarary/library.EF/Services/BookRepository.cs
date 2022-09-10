using Library.Core.DTO;
using Library.Core.Interfaces;
using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.EF.Services
{
    public class BookRepository: IBookRepository
    {
        private readonly AppDBContext _context;
        public BookRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Response> AddBookOnCategoryAsync(List<int> bookAndCat, int bookID)
        {
            foreach (var item in bookAndCat)
            {
                var BookAndCategory = new BookCategory { BookId = bookID, CategoryId = item };
                await _context.BookCategories.AddAsync(BookAndCategory);
                _context.SaveChanges();
            }
            return new Response
            {
                Status = "Success",
                Message = "Books of all kinds have been successfully added"
            };
        }
    }
}
