﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Semkovo.Data;
using Semkovo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Semkovo.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly SemkovoDbContext db;

        public CommentService(SemkovoDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string authorId, string content, int? articleId,int? parentCommentId)
        {
            Comment comment = new Comment
            {
                AuthorId = authorId,
                Content = content,
                ArticleId = articleId,
                CreatedOn = DateTime.Now
            };

            db.Add(comment);
            await this.db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var comment = this.db.Comments.Find(id);

            if (comment != null)
            {
                var subComments = this.db.Comments.Where(c => c.ParentCommentId == id);

                foreach (var subComment in subComments)
                {
                    subComment.ArticleId = null;
                }
                this.db.Remove(comment);
                await this.db.SaveChangesAsync();
            }
        }

    }
}