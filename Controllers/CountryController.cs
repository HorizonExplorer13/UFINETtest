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
        public async Task<IActionResult> GetData([FromQuery] PaginationDTO Pagination, [FromQuery] string Filter)
        {
            var queryable = dbContext.Countries.AsQueryable();
            if (!string.IsNullOrEmpty(Filter))
            {
                queryable = queryable.Where(country =>
                    country.Name.Contains(Filter) ||
                    country.isoCode.Contains(Filter) ||
                    country.Restaurants.Any(restaurant => restaurant.Name.Contains(Filter)) ||
                    country.Hotel.Any(hotel => hotel.Name.Contains(Filter))
                );
            }
            await HttpContext.HeadersInsert(queryable);
            var data = await queryable.OrderBy(c => c.Name).Pager(Pagination).Select(country => new CountryDataDTO
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
        public async Task<ActionResult<List<Country>>> Get([FromQuery] PaginationDTO Pagination, [FromQuery] string Filter)
        {
            var queryable = dbContext.Countries.AsQueryable();
            if (!string.IsNullOrEmpty(Filter))
            {
                    queryable = queryable.Where(country =>
                    country.Name.Contains(Filter) ||
                    country.isoCode.Contains(Filter) ||
                    country.Restaurants.Any(r => r.Name.Contains(Filter)) ||
                    country.Hotel.Any(h => h.Name.Contains(Filter))
                );
            }
            await HttpContext.HeadersInsert(queryable);
            return await queryable.OrderBy(c=>c.Name).Pager(Pagination).Include(r => r.Restaurants).Include(h => h.Hotel).ToListAsync();
        }



    }
}
