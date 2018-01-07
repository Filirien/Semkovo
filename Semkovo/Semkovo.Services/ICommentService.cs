using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Semkovo.Services.Models;


namespace Semkovo.Services
{
    public interface ICommentService
    {
        Task CreateAsync(string authorId, string content, int? articleId);

        Task<bool> Delete(int id);

    }
}
