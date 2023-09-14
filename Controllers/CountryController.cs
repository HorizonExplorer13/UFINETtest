using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UFINETTest.DTOs;
using UFINETTest.Entities;

namespace UFINETTest.Controllers
{
    [ApiController]
    [Route("api/CountryInfo")]
    public class CountryController:ControllerBase
    {
        private readonly AppDbContext dbContext;

        public CountryController(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetData")]
        public async Task<IActionResult> GetData([FromQuery] PaginationDTO Pagination)
        {
            var queryable = dbContext.Countries.AsQueryable();
            await HttpContext.HeadersInsert(queryable);
            var data = await dbContext.Countries.Select(country => new CountryDataDTO
            {
                CountryId = country.CountryId,
                Name = country.Name,
                isoCode = country.isoCode,
                Population = country.Population,
                Restaurants = country.Restaurants.ToList(),
                Hotels = country.Hotel.ToList(),
            }).ToListAsync();
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("AlterGetData")]

        public async Task<IActionResult> AlterGetData()
        {
            var data = await dbContext.Countries.Include(r=>r.Restaurants).Include(h=>h.Hotel).ToListAsync();

            return Ok(data);
        }

        [HttpGet("SecondAltGetData")]
        public async Task<ActionResult<List<Country>>> Get()
        {
            return await dbContext.Countries.Include(r => r.Restaurants).Include(h => h.Hotel).ToListAsync();
        }



    }
}
