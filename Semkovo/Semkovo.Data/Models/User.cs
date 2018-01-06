using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Semkovo.Data.Models
{    
    // This class will be deleted
    public class User : IdentityUser
    {        
        public string FullName { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<ArticleVote> UserVotes { get; set; } = new List<ArticleVote>();
    }
}