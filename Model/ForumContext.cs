using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumManagement.Model;

namespace ForumManagement.Model
{
    public class ForumContext :DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options): base(options)
        {

        }
       

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ForumManagement.Model.User> Users { get; set; }
        public DbSet<ForumManagement.Model.VoteOnQuestion> VoteOnQuestion { get; set; }

       // public DbSet<ForumManagement.Model.LoginUser> LoginUsers { get; set; } 


      
    }


}

