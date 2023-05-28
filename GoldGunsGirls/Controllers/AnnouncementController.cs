using GoldGunsGirls.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldGunsGirls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly ColorBlueContext dbContext;
        public AnnouncementController(ColorBlueContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<AnnouncementApi> Get()
        {
            return dbContext.Announcements.ToList().Select(s => (AnnouncementApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnnouncementApi>> Get(int id)
        {
            var result = await dbContext.Announcements.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((AnnouncementApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AnnouncementApi value)
        {
            var newAnnouncement = (Announcement)value;
            dbContext.Announcements.Add(newAnnouncement);
            await dbContext.SaveChangesAsync();
            return Ok(newAnnouncement.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AnnouncementApi value)
        {
            var oldAnnouncement = await dbContext.Announcements.FindAsync(id);
            if (oldAnnouncement == null)
                return NotFound();
            dbContext.Entry(oldAnnouncement).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldAnnouncement = await dbContext.Announcements.FindAsync(id);
            if (oldAnnouncement == null)
                return NotFound();
            dbContext.Announcements.Remove(oldAnnouncement);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
