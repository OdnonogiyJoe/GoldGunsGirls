using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public ElevatorController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<ElevatorApi> Get()
        {
            return dbContext.Elevators.ToList().Select(s => (ElevatorApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ElevatorApi>> Get(int id)
        {
            var result = await dbContext.Elevators.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((ElevatorApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ElevatorApi value)
        {
            var newElevator = (Elevator)value;
            dbContext.Elevators.Add(newElevator);
            await dbContext.SaveChangesAsync();
            return Ok(newElevator.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ElevatorApi value)
        {
            var oldElevator = await dbContext.Elevators.FindAsync(id);
            if (oldElevator == null)
                return NotFound();
            dbContext.Entry(oldElevator).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldElevator = await dbContext.Elevators.FindAsync(id);
            if (oldElevator == null)
                return NotFound();
            dbContext.Elevators.Remove(oldElevator);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
