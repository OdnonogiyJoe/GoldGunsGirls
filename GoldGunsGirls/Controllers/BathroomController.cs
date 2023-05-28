using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BathroomController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public BathroomController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<BathroomApi> Get()
        {
            return dbContext.Bathrooms.ToList().Select(s => (BathroomApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BathroomApi>> Get(int id)
        {
            var result = await dbContext.Bathrooms.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((BathroomApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] BathroomApi value)
        {
            var newBathroom = (Bathroom)value;
            dbContext.Bathrooms.Add(newBathroom);
            await dbContext.SaveChangesAsync();
            return Ok(newBathroom.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BathroomApi value)
        {
            var oldBathroom = await dbContext.Bathrooms.FindAsync(id);
            if (oldBathroom == null)
                return NotFound();
            dbContext.Entry(oldBathroom).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldBathroom = await dbContext.Bathrooms.FindAsync(id);
            if (oldBathroom == null)
                return NotFound();
            dbContext.Bathrooms.Remove(oldBathroom);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
