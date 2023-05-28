using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public ParkingController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<ParkingApi> Get()
        {
            return dbContext.Parkings.ToList().Select(s => (ParkingApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingApi>> Get(int id)
        {
            var result = await dbContext.Parkings.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((ParkingApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ParkingApi value)
        {
            var newParking = (Parking)value;
            dbContext.Parkings.Add(newParking);
            await dbContext.SaveChangesAsync();
            return Ok(newParking.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ParkingApi value)
        {
            var oldParking = await dbContext.Parkings.FindAsync(id);
            if (oldParking == null)
                return NotFound();
            dbContext.Entry(oldParking).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldParking = await dbContext.Parkings.FindAsync(id);
            if (oldParking == null)
                return NotFound();
            dbContext.Parkings.Remove(oldParking);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
