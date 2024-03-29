using DataLayer.Models;
using DataLayer.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatBot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutorsController : ControllerBase
    {
        private readonly ChatBotContext db;
        public ExecutorsController(ChatBotContext _db)
        {
            db = _db;
        }
        // GET: api/<RolesController>
        [HttpGet]
        public IEnumerable<Executor> GetAll()
        {
            return db.Executor;
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public Executor GetRole(long id)
        {
            Executor SN = db.Executor.Find(id);
            return SN;
        }

        // POST api/<RolesController>
        [HttpPost]
        public void CreateRole([FromBody] Executor SN)
        {
            db.Executor.Add(SN);
            db.SaveChanges();
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public void EditRole(long id, [FromBody] Executor SN)
        {
            if (id == SN.Id)
            {
                db.Entry(SN).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public void DeleteRole(long id)
        {
            Executor SN = db.Executor.Find(id);
            if (SN != null)
            {
                db.Executor.Remove(SN);
                db.SaveChanges();
            }
        }
    }
}
