using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ForumManagement.Model
{
    public class VoteOnQuestion
    {
        public long id { get; set; }

        [ForeignKey("Question")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long? QuestionId { get; set; }

        [ForeignKey("User")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long? UserId { get; set; }
    }
}
