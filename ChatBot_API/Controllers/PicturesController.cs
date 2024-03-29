using DataLayer.Models;
using DataLayer.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatBot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        //ChatBotContext db = new ChatBotContext();
        private readonly ChatBotContext db;
        public PicturesController(ChatBotContext _db)
        {
            db = _db;
        }

        // GET: api/<AppealsController>
        [HttpGet]
        public IEnumerable<Picture> GetAll()
        {
            return db.Pictures;
        }

        // GET api/<AppealsController>/5
        [HttpGet("{id}")]
        public Picture GetAppeal(long id)
        {
            Picture picture = db.Pictures.Find(id);
            return picture;
        }

        // POST api/<AppealsController>
        [HttpPost]
        public void CreateAppeal([FromBody] Picture picture)
        {
            db.Pictures.Add(picture);
            db.SaveChanges();
        }

        // PUT api/<AppealsController>/5
        [HttpPut("{id}")]
        public void EditAppeal(long id, [FromBody] Picture picture)
        {
            if (id == picture.Id)
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // DELETE api/<AppealsController>/5
        [HttpDelete("{id}")]
        public void DeleteAppeal(long id)
        {
            Picture picture = db.Pictures.Find(id);
            if (picture != null)
            {
                db.Pictures.Remove(picture);
                db.SaveChanges();
            }
        }
    }
}
