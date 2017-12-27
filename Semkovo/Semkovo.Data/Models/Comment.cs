using System;

namespace Semkovo.Data.Models
{

    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}