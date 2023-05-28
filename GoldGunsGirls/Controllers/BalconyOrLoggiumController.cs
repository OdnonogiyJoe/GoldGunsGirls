using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalconyOrLoggiumController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public BalconyOrLoggiumController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<BalconyOrLoggiumApi> Get()
        {
            return dbContext.BalconyOrLoggia.ToList().Select(s => (BalconyOrLoggiumApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BalconyOrLoggiumApi>> Get(int id)
        {
            var result = await dbContext.BalconyOrLoggia.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((BalconyOrLoggiumApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] BalconyOrLoggiumApi value)
        {
            var newBalconyOrLoggium = (BalconyOrLoggium)value;
            dbContext.BalconyOrLoggia.Add(newBalconyOrLoggium);
            await dbContext.SaveChangesAsync();
            return Ok(newBalconyOrLoggium.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BalconyOrLoggiumApi value)
        {
            var oldBalconyOrLoggium = await dbContext.Users.FindAsync(id);
            if (oldBalconyOrLoggium == null)
                return NotFound();
            dbContext.Entry(oldBalconyOrLoggium).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldBalconyOrLoggium = await dbContext.BalconyOrLoggia.FindAsync(id);
            if (oldBalconyOrLoggium == null)
                return NotFound();
            dbContext.BalconyOrLoggia.Remove(oldBalconyOrLoggium);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
