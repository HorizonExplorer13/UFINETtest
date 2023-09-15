using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using UFINETTest.DTOs;
using UFINETTest.Entities;
using UFINETTest.Utilitys;

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
        public async Task<ActionResult<List<CountryDataDTO>>> Getalter([FromQuery] PaginationDTO Pagination, [FromQuery] string Filter)
        {
            var queryable = dbContext.Countries.AsQueryable();
            if (!string.IsNullOrEmpty(Filter))
            {
                queryable = queryable.Where(country =>
                country.Name.Contains(Filter) ||
                country.isoCode.Contains(Filter) ||
                country.sites.Any(site => site.Restaurant.Name.Contains(Filter)) ||
                country.sites.Any(site => site.Hotel.Name.Contains(Filter))
            );
            }
            await HttpContext.HeadersInsert(queryable);
            return await queryable.OrderBy(c => c.Name).Pager(Pagination).Include(cs => cs.sites).ThenInclude(r => r.Restaurant).Include(cs => cs.sites).ThenInclude(h => h.Hotel).
                Select(country => new CountryDataDTO
            {
                CountryId = country.CountryId,
                Name = country.Name,
                isoCode = country.isoCode,
                Population = country.Population,
                Restaurants = country.sites.Select(site => site.Restaurant).ToList(),
                Hotels = country.sites.Select(site => site.Hotel).ToList()
            })
        .ToListAsync(); ;

        }



    }
}
