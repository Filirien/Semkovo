using Semkovo.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semkovo.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleListingServiceModel>> AllAsync(int page = 1);

        Task CreateAsync(string authorId, string title, string content);

        Task<bool> DeleteAsync(int id);

        Task EditAsync(int id, string title, string content);

        Task<TModel> ByIdAsync<TModel>(int id) where TModel : class;

        string GetAuthorId(int articleId);
    }
}
