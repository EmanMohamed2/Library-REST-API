using Library.Core.Interfaces;
using Library.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBaseRepository<Category> baseRepository;
        public CategoryController(IBaseRepository<Category> _baseRepository)
        {
            baseRepository = _baseRepository;
        }

        [HttpPost("CreateNewCategory")]
        public async Task<IActionResult> CreateNewBook(string CategoryName)
        {
            var category = new Category {Name=CategoryName };
            var result = await baseRepository.CreateAsync(category);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var Author = await baseRepository.Find(id);
            var result = await baseRepository.Delete(Author);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);

        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Category item)
        {
            var Category = new Category { Id = item.Id, Name = item.Name };
            var result = await baseRepository.UpdateAsync(Category);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var Categories = await baseRepository.GetAllAsync();
            if (Categories == null)
                return BadRequest("There are not Categories");
            return Ok(Categories);

        }
    }
}
