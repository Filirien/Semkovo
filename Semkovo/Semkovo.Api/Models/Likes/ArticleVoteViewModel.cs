using Semkovo.Common.Mapping;
using Semkovo.Data.Models;
using System.ComponentModel.DataAnnotations;

using static Semkovo.Data.DataConstants;

namespace Semkovo.Web.Models.Articles
{
    public class ArticleVoteViewModel : IMapFrom<ArticleVote>
    {
        [Required]
        public int Count { get; set; }
        public int? ArticleId { get; set; }
    }
}
