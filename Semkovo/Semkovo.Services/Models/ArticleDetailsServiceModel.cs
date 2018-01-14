using AutoMapper;
using Semkovo.Common.Mapping;
using Semkovo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semkovo.Services.Models
{
    public class ArticleDetailsServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public int Votes { get; set; }

        public DateTime? CreatedOn { get; set; }

        public List<CommentDetailsServiceModel> Comments { get; set; }

        public void ConfigureMapping(Profile mapper)
             => mapper
                    .CreateMap<Article, ArticleDetailsServiceModel>()
                    .ForMember(mm => mm.Author, cfg => cfg.MapFrom(m => m.Author.UserName))
                    .ForMember(mm => mm.Votes, cfg => cfg.MapFrom(m => m.ArticleVotes.Sum(v => v.Count)));
    }
}
