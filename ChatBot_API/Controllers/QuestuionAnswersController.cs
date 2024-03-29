using DataLayer.Models;
using DataLayer.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatBot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestuionAnswersController : ControllerBase
    {
        private readonly ChatBotContext db;
        public QuestuionAnswersController(ChatBotContext _db)
        {
            db = _db;
        }
        // GET: api/<QuestuionAnswersController>
        [HttpGet]
        public IEnumerable<QuestionAnswer> GetAll()
        {
            return db.QuestionAnswer;
        }

        // GET api/<QuestuionAnswersController>/5
        [HttpGet("{id}")]
        public QuestionAnswer GetQuestionAnswer(long id)
        {
            QuestionAnswer SN = db.QuestionAnswer.Find(id);
            return SN;
        }

        // POST api/<QuestuionAnswersController>
        [HttpPost]
        public void CreateQuestionAnswer([FromBody] QuestionAnswer SN)
        {
            db.QuestionAnswer.Add(SN);
            db.SaveChanges();
        }

        // PUT api/<QuestuionAnswersController>/5
        [HttpPut("{id}")]
        public void EditQuestionAnswer(long id, [FromBody] QuestionAnswer SN)
        {
            if (id == SN.Id)
            {
                db.Entry(SN).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // DELETE api/<QuestuionAnswersController>/5
        [HttpDelete("{id}")]
        public void DeleteQuestionAnswer(long id)
        {
            QuestionAnswer SN = db.QuestionAnswer.Find(id);
            if (SN != null)
            {
                db.QuestionAnswer.Remove(SN);
                db.SaveChanges();
            }
        }
    }
}
