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

        public async Task<TModel> ByIdAsync<TModel>(int id) where TModel : class
            => await this.db
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<TModel>()
                .FirstOrDefaultAsync();

        public async Task CreateAsync(string authorId, string title, string content)
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

        public async Task<bool> DeleteAsync(int id)
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

            var votes = this.db.ArticleVotes.Where(av => av.ArticleId == article.Id);

            this.db.RemoveRange(votes);
            this.db.Remove(article);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task EditAsync(int id, string title, string content)
        {
            var article = this.db.Articles.Find(id);

            if (article != null)
            {
                article.Title = title;
                article.Content = content;

                await this.db.SaveChangesAsync();
            }
        }

        public string GetAuthorId(int articleId)
            => this.db
                .Articles
                .FirstOrDefault(a => a.Id == articleId)
                ?.AuthorId;

        public async Task<int> AddOrUpdateVote(int memeId, string userId, int value)
        {
            if (!await this.DoesArticleExistAsync(memeId))
            {
                return -1;
            }
            var vote = this.db.ArticleVotes
                .Where(m => m.ArticleId == memeId && m.UserId == userId)
                .FirstOrDefault();

            value = this.NormalizeValue(value);

            if (vote == null)
            {
                vote = new ArticleVote
                {
                    Count = value,
                    ArticleId = memeId,
                    UserId = userId
                };

                this.db.Add(vote);
            }
            else
            {
                var difference = vote.Count + value;
                vote.Count = this.NormalizeValue(difference); ;
            }

            await this.db.SaveChangesAsync();

            return await this.Votes(memeId);
        }

        public async Task<int> Votes(int memeId)
        {
            if (!await this.DoesArticleExistAsync(memeId))
            {
                return -1;
            }

            return this.db.ArticleVotes.Where(v => v.ArticleId == memeId).Select(v => v.Count).DefaultIfEmpty(0).Sum();
        }

        private int NormalizeValue(int value)
        {
            if (value > 1)
            {
                value = 1;
            }
            if (value < -1)
            {
                value = -1;
            }
            return value;
        }

        public async Task<bool> DoesArticleExistAsync(int id)
           => await this.db.Articles.AnyAsync(m => m.Id == id);
    }
}
