using Library.Core.Interfaces;
using Library.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IBaseRepository<Country> baseRepository;
        public CountriesController(IBaseRepository<Country> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        [HttpPost("CreateNewCountry")]
        public async Task<IActionResult> CreateNewCountry(string countryName)
        {
            var country = new Country { Name = countryName};
            var result = await baseRepository.CreateAsync(country);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var Country = await baseRepository.Find(id);
            var result = await baseRepository.Delete(Country);
            if (result.Status == "Fail")
                return BadRequest(result);
            return Ok(result);

        }
   
        [HttpGet("GetAllCountry")]
        public async Task<IActionResult> GetAllCountry()
        {
            var Countries = await baseRepository.GetAllAsync();
            if (Countries == null)
                return BadRequest("There are not Countries");
            return Ok(Countries);

        }
    }
}
