using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public RepairController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<RepairApi> Get()
        {
            return dbContext.Repairs.ToList().Select(s => (RepairApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepairApi>> Get(int id)
        {
            var result = await dbContext.Repairs.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((RepairApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] RepairApi value)
        {
            var newRepair = (Repair)value;
            dbContext.Repairs.Add(newRepair);
            await dbContext.SaveChangesAsync();
            return Ok(newRepair.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RepairApi value)
        {
            var oldRepair = await dbContext.Repairs.FindAsync(id);
            if (oldRepair == null)
                return NotFound();
            dbContext.Entry(oldRepair).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldRepair = await dbContext.Repairs.FindAsync(id);
            if (oldRepair == null)
                return NotFound();
            dbContext.Repairs.Remove(oldRepair);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
