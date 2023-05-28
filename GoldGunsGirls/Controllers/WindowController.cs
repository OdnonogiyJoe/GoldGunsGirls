using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public WindowController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<WindowApi> Get()
        {
            return dbContext.Windows.ToList().Select(s => (WindowApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WindowApi>> Get(int id)
        {
            var result = await dbContext.Windows.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((WindowApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] WindowApi value)
        {
            var newWindow = (Window)value;
            dbContext.Windows.Add(newWindow);
            await dbContext.SaveChangesAsync();
            return Ok(newWindow.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] WindowApi value)
        {
            var oldWindow = await dbContext.Windows.FindAsync(id);
            if (oldWindow == null)
                return NotFound();
            dbContext.Entry(oldWindow).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldWindow = await dbContext.Windows.FindAsync(id);
            if (oldWindow == null)
                return NotFound();
            dbContext.Windows.Remove(oldWindow);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
