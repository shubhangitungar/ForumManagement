using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumManagement
{
    public class QAResponse
    {
        public  QuestionResponse question { get; set;}
        /*
          public long id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string author { get; set; }

         */
        public List<AnswerResponse> answers { get; set; }
    }
}
