using DataLayer.Models;
using DataLayer.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatBot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly ChatBotContext db;
        public StatusesController(ChatBotContext _db)
        {
            db = _db;
        }
        // GET: api/<StatusesController>
        [HttpGet]
        public IEnumerable<Status> GetAll()
        {
            return db.Status;
        }

        // GET api/<StatusesController>/5
        [HttpGet("{id}")]
        public Status GetStatus(long id)
        {
            Status SN = db.Status.Find(id);
            return SN;
        }

        // POST api/<StatusesController>
        [HttpPost]
        public void CreateStatus([FromBody] Status SN)
        {
            db.Status.Add(SN);
            db.SaveChanges();
        }

        // PUT api/<StatusesController>/5
        [HttpPut("{id}")]
        public void EditStatus(long id, [FromBody] Status SN)
        {
            if (id == SN.Id)
            {
                db.Entry(SN).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // DELETE api/<StatusesController>/5
        [HttpDelete("{id}")]
        public void DeleteStatus(long id)
        {
            Status SN = db.Status.Find(id);
            if (SN != null)
            {
                db.Status.Remove(SN);
                db.SaveChanges();
            }
        }
    }
}
