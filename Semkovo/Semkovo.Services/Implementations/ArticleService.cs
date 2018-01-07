using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Semkovo.Services.Models;
using Semkovo.Data;
using System.Linq;

using static Semkovo.Services.ServiceConstants;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Semkovo.Data.Models;

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

        public async Task CreateArticle(string authorId, string title, string content)
        {
            Article article = new Article
            {
                Title = title,
                Content = content,
                AuthorId = authorId,
                CreatedOn = DateTime.Now
            };

            this.db.Add(article);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var article = this.db.Articles.Find(id);

            if (article == null)
            {
                return false;
            }

            var articleComments = this.db.Comments.Where(c => c.ArticleId == id);

            foreach (var comment in articleComments)
            {
                comment.ArticleId = null;
            }

            this.db.Remove(article);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task Edit(int id, string title, string content)
        {
            var article = this.db.Articles.Find(id);

            if (article != null)
            {
                article.Title = title;
                article.Content = content;

                await this.db.SaveChangesAsync();
            }
        }
    }
}
