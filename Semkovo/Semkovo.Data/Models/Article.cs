using System;
using System.Collections.Generic;

namespace Semkovo.Data.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public DateTime? CreatedOn { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<ArticleVote> ArticleVotes { get; set; } = new List<ArticleVote>();
    }
}
