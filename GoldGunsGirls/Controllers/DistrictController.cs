using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public DistrictController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<DistrictApi> Get()
        {
            return dbContext.Districts.ToList().Select(s => (DistrictApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DistrictApi>> Get(int id)
        {
            var result = await dbContext.Districts.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((DistrictApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] DistrictApi value)
        {
            var newDistrict = (District)value;
            dbContext.Districts.Add(newDistrict);
            await dbContext.SaveChangesAsync();
            return Ok(newDistrict.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DistrictApi value)
        {
            var oldDistrict = await dbContext.Districts.FindAsync(id);
            if (oldDistrict == null)
                return NotFound();
            dbContext.Entry(oldDistrict).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldDistrict = await dbContext.Districts.FindAsync(id);
            if (oldDistrict == null)
                return NotFound();
            dbContext.Districts.Remove(oldDistrict);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
