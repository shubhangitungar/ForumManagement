using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<QuestionResponse> Get()
        {
            //var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new QuestionResponse
            {
                id = index, 
                title = "Test Question " + index,
                description = "Test Description " + index,
                author = "Shubhangi"
            })
            .ToArray();
        }

        //Get by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<QAResponse>> GetQuestion(long id)
        {

            Console.WriteLine(id);
            return new QAResponse
            {
                question = new QuestionResponse
                {
                    id = id,
                    title = "Test Question " + id,
                    description = "Test Description " + id,
                    author = "Shubhangi"
                },
                answers = Enumerable.Range(1, 3).Select(index => new AnswerResponse
                {
                    id = index,
                    description = "Test Answer " + index,
                    author = "Shubhangi"
                })
            .ToArray().ToList()
        };            
        }

    }
}
