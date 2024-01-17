using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSolution.Models;

namespace WebApiSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuestionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionItems()
        {
            return await _context.QuestionItems.ToListAsync();
        }
        [HttpGet("{level}")]
        public async Task<ActionResult<Question>> GetLevelQuestion(int level)
        {
            var question=await _context.QuestionItems.Where(x=>x.level.Equals(level)).OrderBy(r => Guid.NewGuid()).Take(1).ToListAsync();
            return question[0];
        }




        // GET: api/Questions/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Question>> GetQuestion(int id)
        //{
        //    var question = await _context.QuestionItems.FindAsync(id);

        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    return question;
        //}

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.Id)
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

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Question>> PostQuestion(Question question)
        //{
        //    _context.QuestionItems.Add(question);
        //    await _context.SaveChangesAsync();

        //   // return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        //    return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
        //}

        [HttpPost]
        public async Task<ActionResult<bool>> PostListQuestion(List<Question> questionList)
        {
            _context.QuestionItems.AddRange(questionList);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.QuestionItems.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.QuestionItems.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return _context.QuestionItems.Any(e => e.Id == id);
        }
    }
}
