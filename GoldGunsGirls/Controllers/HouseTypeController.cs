using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseTypeController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public HouseTypeController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<HouseTypeApi> Get()
        {
            return dbContext.HouseTypes.ToList().Select(s => (HouseTypeApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HouseTypeApi>> Get(int id)
        {
            var result = await dbContext.HouseTypes.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((HouseTypeApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] HouseTypeApi value)
        {
            var newHouseType = (HouseType)value;
            dbContext.HouseTypes.Add(newHouseType);
            await dbContext.SaveChangesAsync();
            return Ok(newHouseType.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] HouseTypeApi value)
        {
            var oldHouseType = await dbContext.HouseTypes.FindAsync(id);
            if (oldHouseType == null)
                return NotFound();
            dbContext.Entry(oldHouseType).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldHouseType = await dbContext.HouseTypes.FindAsync(id);
            if (oldHouseType == null)
                return NotFound();
            dbContext.HouseTypes.Remove(oldHouseType);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
