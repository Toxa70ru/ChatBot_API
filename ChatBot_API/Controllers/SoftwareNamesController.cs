using DataLayer.Models;
using DataLayer.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatBot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareNamesController : ControllerBase
    {
        private readonly ChatBotContext db;
        public SoftwareNamesController(ChatBotContext _db)
        {
            db = _db;
        }
        // GET: api/<SoftwareNamesController>
        [HttpGet]
        public IEnumerable<SoftwareName> GetAll()
        {
            return db.softwareNames;
        }

        // GET api/<SoftwareNamesController>/5
        [HttpGet("{id}")]
        public SoftwareName GetSoftwareName(long id)
        {
            SoftwareName SN = db.softwareNames.Find(id);
            return SN;
        }

        // POST api/<SoftwareNamesController>
        [HttpPost]
        public void CreateSoftwareName([FromBody] SoftwareName SN)
        {
            db.softwareNames.Add(SN);
            db.SaveChanges();
        }

        // PUT api/<SoftwareNamesController>/5
        [HttpPut("{id}")]
        public void EditSoftwareName(long id, [FromBody] SoftwareName SN)
        {
            if (id == SN.Id)
            {
                db.Entry(SN).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // DELETE api/<SoftwareNamesController>/5
        [HttpDelete("{id}")]
        public void DeleteSoftwareName(long id)
        {
            SoftwareName SN = db.softwareNames.Find(id);
            if (SN != null)
            {
                db.softwareNames.Remove(SN);
                db.SaveChanges();
            }
        }
    }
}
