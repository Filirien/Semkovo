using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Semkovo.Services.Models;


namespace Semkovo.Services
{
    public interface ICommentService
    {
        Task CreateAsync(string authorId, string content, int? articleId, int? parentCommentId);

        Task Delete(int id);

        Task<int?> GetArticleId(int commentId);

        Task<string> GetAuthorId(int id);
    }
}
