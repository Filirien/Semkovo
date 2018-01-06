using Semkovo.Common.Mapping;
using Semkovo.Data.Models;
using System;

namespace Semkovo.Services.Models
{
    public class ArticleListingServiceModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        
        public string Author { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
