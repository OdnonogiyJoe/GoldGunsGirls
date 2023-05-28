using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public StatusController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<StatusApi> Get()
        {
            return dbContext.Statuses.ToList().Select(s => (StatusApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusApi>> Get(int id)
        {
            var result = await dbContext.Statuses.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((StatusApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] StatusApi value)
        {
            var newStatus = (Status)value;
            dbContext.Statuses.Add(newStatus);
            await dbContext.SaveChangesAsync();
            return Ok(newStatus.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StatusApi value)
        {
            var oldStatus = await dbContext.Statuses.FindAsync(id);
            if (oldStatus == null)
                return NotFound();
            dbContext.Entry(oldStatus).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldStatus = await dbContext.Statuses.FindAsync(id);
            if (oldStatus == null)
                return NotFound();
            dbContext.Statuses.Remove(oldStatus);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
