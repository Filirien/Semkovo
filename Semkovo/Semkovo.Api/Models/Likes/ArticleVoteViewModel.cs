using Semkovo.Common.Mapping;
using Semkovo.Data.Models;

namespace Semkovo.Web.Models.Articles
{
    public class ArticleVoteViewModel : IMapFrom<ArticleVote>
    {
        public int Value { get; set; }

        public int ArticleId { get; set; }
    }
}
