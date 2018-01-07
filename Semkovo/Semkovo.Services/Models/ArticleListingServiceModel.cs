using Semkovo.Common.Mapping;
using Semkovo.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

using static Semkovo.Data.DataConstants;

namespace Semkovo.Services.Models
{
    public class ArticleListingServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ArticleTitleMaxLength, MinimumLength = ArticleTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ArticleContentMaxLength, MinimumLength = ArticleContentMinLength)]
        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime? CreatedOn { get; set; }

        public void ConfigureMapping(Profile mapper)
             => mapper
                    .CreateMap<Article, ArticleListingServiceModel>()
                    .ForMember(mm => mm.Author, cfg => cfg.MapFrom(m => m.Author.UserName));
    }
}
