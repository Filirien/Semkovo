using Semkovo.Common.Mapping;
using Semkovo.Data.Models;
using System.ComponentModel.DataAnnotations;

using static Semkovo.Data.DataConstants;

namespace Semkovo.Web.Models.Articles
{
    public class ArticleCreateViewModel : IMapFrom<Article>
    {
        [Required]
        [StringLength(ArticleTitleMaxLength, MinimumLength = ArticleTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ArticleContentMaxLength, MinimumLength = ArticleContentMinLength)]
        public string Content { get; set; }
    }
}
