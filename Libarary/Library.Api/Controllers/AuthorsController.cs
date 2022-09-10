
using Library.Core.DTO;
using Library.Core.Interfaces;
using Library.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepository<Author> baseRepository;
        public AuthorsController(IBaseRepository<Author> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        [HttpPost("CreateNewAuthor")]
        public async Task<IActionResult> CreateNewAuthor(AuthorDto AuthorDto)
        {
            var author = new Author { Name = AuthorDto.Name, CountryId= AuthorDto .CountryID};
            var result = await baseRepository.CreateAsync(author);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("DeleteAuthor")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var Author = await baseRepository.Find(id);
            var result = await baseRepository.Delete(Author);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);

        }
        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(Author item)
        {
            var Author=new Author { Id=item.Id,CountryId= item.CountryId};
            var result = await baseRepository.UpdateAsync(Author);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetAllAuthor")]
        public async Task<IActionResult> GetAllAuthor()
        {
            var Authors = await baseRepository.GetAllAsync();
            if (Authors == null)
                return BadRequest("There are not Authors");
            return Ok(Authors);

        }
    }
}
