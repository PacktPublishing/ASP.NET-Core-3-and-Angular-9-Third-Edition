using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldCities.Data;
using WorldCities.Data.Models;

namespace WorldCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        // GET: api/Countries/?pageIndex=0&pageSize=10
        // GET: api/Countries/?pageIndex=0&pageSize=10&sortColumn=name&sortOrder=asc
        // GET: api/Countries/?pageIndex=0&pageSize=10&sortColumn=name&sortOrder=asc&filterColumn=name&filterQuery=york
        [HttpGet]
        public async Task<ActionResult<ApiResult<Country>>> GetCountries(
                int pageIndex = 0,
                int pageSize = 10,
                string sortColumn = null,
                string sortOrder = null,
                string filterColumn = null,
                string filterQuery = null)
        {
            return await ApiResult<Country>.CreateAsync(
                    _context.Countries,
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }


        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return country;
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }

        [HttpPost]
        [Route("IsDupeField")]
        public bool IsDupeField(
            int countryId, 
            string fieldName, 
            string fieldValue)
        {
            // Standard approach(using strongly-typed LAMBA expressions)
            //switch (fieldName)
            //{
            //    case "name":
            //        return _context.Countries.Any(
            //            c => c.Name == fieldValue && c.Id != countryId);
            //    case "iso2":
            //        return _context.Countries.Any(
            //            c => c.ISO2 == fieldValue && c.Id != countryId);
            //    case "iso3":
            //        return _context.Countries.Any(
            //            c => c.ISO3 == fieldValue && c.Id != countryId);
            //    default:
            //        return false;
            //}

            // Dynamic approach (using System.Linq.Dynamic.Core)
            return (ApiResult<Country>.IsValidProperty(fieldName, true))
                ? _context.Countries.Any(
                    String.Format("{0} == @0 && Id != @1", fieldName),
                    fieldValue,
                    countryId)
                : false;
        }
    }
}
