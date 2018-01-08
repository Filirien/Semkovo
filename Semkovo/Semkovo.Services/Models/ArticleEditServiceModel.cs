using System;
using System.ComponentModel.DataAnnotations;

using static Semkovo.Data.DataConstants;

namespace Semkovo.Services.Models
{
    public class ArticleEditServiceModel
    {
        [Required]
        [StringLength(ArticleTitleMaxLength, MinimumLength = ArticleTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ArticleContentMaxLength, MinimumLength = ArticleContentMinLength)]
        public string Content { get; set; }
    }
}
