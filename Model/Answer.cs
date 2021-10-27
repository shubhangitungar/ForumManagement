using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ForumManagement.Model
{
    public class Answer
    {

        public long id { get; set; }

        public string description { get; set; }

        // public string author { get; set; }
        [ForeignKey("User")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long? UserId { get; set; }
        public User User { get; set; }


        /*   [ForeignKey("QuestionId")]
           public int QuestionId { get; set; }

           public virtual Question Question { get; set; }*/


        [ForeignKey("Question")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long? QuestionId { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
    }
}
