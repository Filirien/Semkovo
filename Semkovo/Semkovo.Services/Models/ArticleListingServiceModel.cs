using Semkovo.Common.Mapping;
using Semkovo.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

using static Semkovo.Data.DataConstants;
using System.Linq;

namespace Semkovo.Services.Models
{
    public class ArticleListingServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime? CreatedOn { get; set; }
        
        public int Comments { get; set; }

        public int Votes { get; set; }

        public void ConfigureMapping(Profile mapper)
             => mapper
                    .CreateMap<Article, ArticleListingServiceModel>()
                    .ForMember(mm => mm.Comments, cfg => cfg.MapFrom(m => m.Comments.Count))
                    .ForMember(mm => mm.Author, cfg => cfg.MapFrom(m => m.Author.UserName))
                    .ForMember(mm => mm.Votes, cfg => cfg.MapFrom(m => m.ArticleVotes.Sum(v => v.Count)));
    }
}
