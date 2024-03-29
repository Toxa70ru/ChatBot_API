using DataLayer.Models;
using DataLayer.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatBot_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AppealsController : ControllerBase
    {
        //ChatBotContext db = new ChatBotContext();
        private readonly ChatBotContext db;
        public AppealsController(ChatBotContext _db)
        {
            db = _db;
        }

        // GET: api/<AppealsController>
        [HttpGet]
        public IEnumerable<Appeal> GetAll()
        {
            return db.Appeal;
        }

        // GET api/<AppealsController>/5
        [HttpGet("{id}")]
        public Appeal GetAppeal(long id)
        {
            Appeal appeal = db.Appeal.Find(id);
            return appeal;
        }

        // POST api/<AppealsController>
        [HttpPost]
        public void CreateAppeal([FromBody] Appeal appeal)
        {
            db.Appeal.Add(appeal);
            db.SaveChanges();
        }

        // PUT api/<AppealsController>/5
        [HttpPut("{id}")]
        public void EditAppeal(long id, [FromBody] Appeal appeal)
        {
            if (id == appeal.Id)
            {
                db.Entry(appeal).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // DELETE api/<AppealsController>/5
        [HttpDelete("{id}")]
        public void DeleteAppeal(long id)
        {
            Appeal appeal = db.Appeal.Find(id);
            if (appeal != null)
            {
                db.Appeal.Remove(appeal);
                db.SaveChanges();
            }
        }
    }
}
