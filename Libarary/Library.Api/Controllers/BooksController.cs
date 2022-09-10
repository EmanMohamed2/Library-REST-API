using Library.Core.DTO;
using Library.Core.Interfaces;
using Library.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> baseRepository;
        private readonly IBookRepository bookRepository;
        public BooksController(IBaseRepository<Book> _baseRepository, IBookRepository _bookRepository)
        {
            baseRepository = _baseRepository;
            bookRepository= _bookRepository;
        }
        [HttpPost("CreateNewBook")]
        public async Task<IActionResult> CreateNewBook(BookDto bookDTO)
        {
            var book = new Book { Name = bookDTO.Name,Isbn= bookDTO.Isbn,DatePublished= bookDTO.DatePublished,AuthorID= bookDTO.AuthorID };
           
            var result = await baseRepository.CreateAsync(book);
            await bookRepository.AddBookOnCategoryAsync(bookDTO.categories,book.Id);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var Author = await baseRepository.Find(id);
            var result = await baseRepository.Delete(Author);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);

        }
        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook(Book item)
        {
            var Book = new Book { Id = item.Id, DatePublished = item.DatePublished,Isbn=item.Isbn,AuthorID=item.AuthorID };
            var result = await baseRepository.UpdateAsync(Book);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetAllBook")]
        public async Task<IActionResult> GetAllBook()
        {
            var books = await baseRepository.GetAllAsync();
            if (books==null)
                return BadRequest("There are not Books");
            return Ok(books);
        }
    }
}
