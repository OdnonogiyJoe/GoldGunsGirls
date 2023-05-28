using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentTypeController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public ApartmentTypeController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<ApartmentTypeApi> Get()
        {
            return dbContext.ApartmentTypes.ToList().Select(s => (ApartmentTypeApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApartmentTypeApi>> Get(int id)
        {
            var result = await dbContext.ApartmentTypes.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((ApartmentTypeApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ApartmentTypeApi value)
        {
            var newApartmentType = (ApartmentType)value;
            dbContext.ApartmentTypes.Add(newApartmentType);
            await dbContext.SaveChangesAsync();
            return Ok(newApartmentType.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ApartmentTypeApi value)
        {
            var oldApartmentType = await dbContext.ApartmentTypes.FindAsync(id);
            if (oldApartmentType == null)
                return NotFound();
            dbContext.Entry(oldApartmentType).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldApartmentType = await dbContext.ApartmentTypes.FindAsync(id);
            if (oldApartmentType == null)
                return NotFound();
            dbContext.ApartmentTypes.Remove(oldApartmentType);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
