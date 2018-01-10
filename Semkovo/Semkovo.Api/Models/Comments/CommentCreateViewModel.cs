using System.ComponentModel.DataAnnotations;

using static Semkovo.Data.DataConstants;

namespace Semkovo.Web.Models.Comments
{
    public class CommentCreateViewModel
    {
        [Required]
        [StringLength(CommentContentMaxLength, MinimumLength = CommentContentMinLength)]
        public string Content { get; set; }

        public int? ArticleId { get; set; }

        public int? ParentCommentId { get; set; }
    }
}
