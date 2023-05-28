using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public UserController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<UserApi> Get()
        {
            return dbContext.Users.ToList().Select(s => (UserApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserApi>> Get(int id)
        {
            var result = await dbContext.Users.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((UserApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] UserApi value)
        {
            var newUser = (User)value;
            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync();
            return Ok(newUser.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserApi value)
        {
            var oldUser = await dbContext.Users.FindAsync(id);
            if (oldUser == null)
                return NotFound();
            dbContext.Entry(oldUser).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldUser = await dbContext.Users.FindAsync(id);
            if (oldUser == null)
                return NotFound();
            dbContext.Users.Remove(oldUser);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
