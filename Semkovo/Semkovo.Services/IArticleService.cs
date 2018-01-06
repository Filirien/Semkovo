using Semkovo.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semkovo.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleListingServiceModel>> AllAsync(int page = 1);

        Task CreateArticle(string authorId, string title, string content);

        Task<bool> Delete(int id);
    }
}
