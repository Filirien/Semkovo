using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Semkovo.Services.Models;
using Semkovo.Data;
using System.Linq;

using static Semkovo.Services.ServiceConstants;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Semkovo.Services.Implementations
{
    public class ArticleService : IArticleService
    {
        private SemkovoDbContext db;

        public ArticleService(SemkovoDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ArticleListingServiceModel>> AllAsync(int page = 1)
            => await this.db
                .Articles
                .OrderByDescending(m => m.CreatedOn)
                .Skip((page - 1) * MemesPageSize)
                .Take(MemesPageSize)
                .ProjectTo<ArticleListingServiceModel>()
                .ToListAsync();
    }
}
