using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForumManagement.Model;

namespace ForumManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteOnQuestionController : ControllerBase
    {
        private readonly ForumContext _context;

        public VoteOnQuestionController(ForumContext context)
        {
            _context = context;
        }

        private IEnumerable<VoteOnQuestion> GetVoteOnQuestion(long userId, long questionId)
        {
            return _context.VoteOnQuestion.Where(q => q.UserId == userId && q.QuestionId == questionId).ToList();
        }

        // POST: api/Vote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VoteOnQuestion>> PostVoteOnQuestion(VoteOnQuestion voteOnQuestion)
        {
            List<VoteOnQuestion> votes = GetVoteOnQuestion(voteOnQuestion.UserId ?? 0, voteOnQuestion.QuestionId ?? 0).ToList();
            if (votes.Count > 0)
            {
                throw new Exception("Already upvoted");
            }

            _context.VoteOnQuestion.Add(voteOnQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostVoteOnQuestion", new { id = voteOnQuestion.id }, voteOnQuestion);
        }

        
        // DELETE: api/Vote/5
        [HttpDelete]
        public async Task<IActionResult> DeleteVoteOnQuestion(long userId, long questionId)
        {
            List<VoteOnQuestion> votes = GetVoteOnQuestion(userId, questionId).ToList();
            if (votes.Count <= 0)
            {
                throw new Exception("Cannot downvote");
            }

            var voteOnQuestion = await _context.VoteOnQuestion.FindAsync(votes.ElementAt(0).id);
            if (voteOnQuestion == null)
            {
                return NotFound();
            }

            _context.VoteOnQuestion.Remove(voteOnQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
