using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public CityController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<CityApi> Get()
        {
            return dbContext.Cities.ToList().Select(s => (CityApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityApi>> Get(int id)
        {
            var result = await dbContext.Cities.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((CityApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CityApi value)
        {
            var newCity = (City)value;
            dbContext.Cities.Add(newCity);
            await dbContext.SaveChangesAsync();
            return Ok(newCity.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CityApi value)
        {
            var oldCity = await dbContext.Cities.FindAsync(id);
            if (oldCity == null)
                return NotFound();
            dbContext.Entry(oldCity).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldCity = await dbContext.Cities.FindAsync(id);
            if (oldCity == null)
                return NotFound();
            dbContext.Cities.Remove(oldCity);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
