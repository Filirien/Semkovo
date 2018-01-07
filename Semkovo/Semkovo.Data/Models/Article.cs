using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Semkovo.Data.DataConstants;

namespace Semkovo.Data.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ArticleTitleMaxLength, MinimumLength = ArticleTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ArticleContentMaxLength, MinimumLength = ArticleContentMinLength)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public DateTime? CreatedOn { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<ArticleVote> ArticleVotes { get; set; } = new List<ArticleVote>();
    }
}
