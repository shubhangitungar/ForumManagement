using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForumManagement.Model;
using System;
using Microsoft.AspNetCore.Authorization;

namespace ForumManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NewQuestionsController : ControllerBase
    {
        
        private readonly ForumContext _context;
       
        public NewQuestionsController(ForumContext context)
        {
            _context = context;
        }

        // GET: api/NewQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions(string key)
        {
            Console.WriteLine("key = " + key);
            List<Question> questions;
            if (key != null)
            {
                questions = _context.Questions.Include(q => q.User).Include(q => q.Votes).Where(x => x.title.ToLower().Contains(key.ToLower())).ToList();
                return questions;
            }

            //return await _context.Questions.ToListAsync();

            questions = await _context.Questions.Include(q => q.User).Include(q => q.Votes).ToListAsync();
            return questions;

        }

        // GET: api/NewQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(long id)
        {
            var question = await _context.Questions
                .Include(q => q.User)
                .Include(q => q.Votes)
                .Include(q => q.Answers)
                .ThenInclude(a => a.User)
                .FirstOrDefaultAsync(i => i.id == id);
            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // PUT: api/NewQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(long id, Question question)
        {
            if (id != question.id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NewQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.id }, question);
        }

        // DELETE: api/NewQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(long id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(long id)
        {
            return _context.Questions.Any(e => e.id == id);
        }

/*
        // GET: api/NewQuestions/5
      [HttpGet("/search")]
        public async Task<ActionResult<IEnumerable<Question>>> Search(string key)
        {
            // List<Question> questions => object p = Question.Where(x => x.title.tolower().Contains(search.ToLower()).ToList();

            // x => img.Title.ToLower().Contains(SearchText.ToLower())).ToList();
            // return View(db.Students.Where(x = > x.Name.StartsWith(search) || search == null).ToList()); 

           List<Question> questions =  _context.Questions.Where(x => x.title.ToLower().Contains(key.ToLower())).ToList();
            // return  _context.Questions.Where(x => x.title.ToLower().Contains(search.ToLower())).ToList();
            return questions;
        }
*/

        

    }
}

