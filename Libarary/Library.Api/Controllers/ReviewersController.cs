using Library.Core.DTO;
using Library.Core.Interfaces;
using Library.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewersController : ControllerBase
    {
        private readonly IBaseRepository<Reviewer> baseRepository;
        public ReviewersController(IBaseRepository<Reviewer> _baseRepository)
        {
            baseRepository= _baseRepository;
        }
        [HttpPost("CreateNewReviewer")]
        public async Task<IActionResult> CreateNewReviewer(ReviewerDto ReviewerDto)
        {
            var Reviewer = new Reviewer { FirstName = ReviewerDto.FirstName, LastName = ReviewerDto.LastName};
            var result = await baseRepository.CreateAsync(Reviewer);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("DeleteReviewer")]
        public async Task<IActionResult> DeleteReviewer(int id)
        {
            var Author = await baseRepository.Find(id);
            var result = await baseRepository.Delete(Author);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);

        }
        [HttpPut("UpdateReviewer")]
        public async Task<IActionResult> UpdateReviewer(Reviewer item)
        {
            var Reviewer = new Reviewer { Id = item.Id,FirstName=item.FirstName,LastName=item.LastName };
            var result = await baseRepository.UpdateAsync(Reviewer);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetAllReviewer")]
        public async Task<IActionResult> GetAllReviewer()
        {
            var Reviewer = await baseRepository.GetAllAsync();
            if (Reviewer == null)
                return BadRequest("There are not Reviewers");
            return Ok(Reviewer);

        }
    }
}
