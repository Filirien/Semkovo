using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Semkovo.Data.Models
{

    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int? ArticleId { get; set; }

        public Article Article { get; set; }

        public int? ParentCommentId { get; set; }

        public Comment ParentComment { get; set; }
        
        [Required]
        public string AuthorId { get; set; }

        public User Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<Comment> ChildrenComments { get; set; } = new List<Comment>();
    }
}