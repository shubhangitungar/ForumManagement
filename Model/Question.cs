using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ForumManagement.Model
{
    public class Question
    {
        
        public long id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime createdDate { get; set; }



        //public string author { get; set; }

        [ForeignKey("User")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long? UserId { get; set; }
        public User User { get; set; }

        //public ICollection<Answer> Answers { get; set; }
        public virtual List<Answer> Answers { get; set; }

        public virtual List<VoteOnQuestion> Votes { get; set; }
    }
}
