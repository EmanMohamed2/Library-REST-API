
using Library.Core.DTO;
using Library.Core.Interfaces;
using Library.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IBaseRepository<Review> baseRepository;
        public ReviewsController(IBaseRepository<Review> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        [HttpPost("CreateNewReview")]
        public async Task<IActionResult> CreateNewReview(ReviewDto ReviewDto)
        {
            var Review = new Review
            { DateWriting = ReviewDto.DateWriting, ReviewText = ReviewDto.ReviewText,Rating= ReviewDto .Rating,BookID= ReviewDto.BookID ,ReviewerID= ReviewDto .ReviewerID};
            var result = await baseRepository.CreateAsync(Review);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("DeleteReview")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var Review = await baseRepository.Find(id);
            if (Review == null)
                return BadRequest("Not found this Review");
            var result = await baseRepository.Delete(Review);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);

        }
        [HttpPut("UpdateReview")]
        public async Task<IActionResult> UpdateReviewer(Review item)
        {
            var find_review = await baseRepository.Find(item.Id);
            if(find_review is null)
                return NotFound("The review not found");
            var Review = new Review { Id = item.Id, DateWriting=item.DateWriting,Rating=item.Rating, ReviewText = item.ReviewText };
            var result = await baseRepository.UpdateAsync(Review);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetAllReview")]
        public async Task<IActionResult> GetAllReview()
        {
            var Reviews = await baseRepository.GetAllAsync();
            if (Reviews == null)
                return BadRequest("There are not Reviews");
            return Ok(Reviews);

        }
    }
}
