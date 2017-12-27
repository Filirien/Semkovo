using System;
using System.Collections.Generic;

namespace Semkovo.Data.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ArticleVote> ArticleVotes { get; set; }
    }
}
