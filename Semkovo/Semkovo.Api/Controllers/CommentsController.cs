using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Semkovo.Data.Models;
using Semkovo.Services;
using Semkovo.Web.Infrastructure.Extensions;
using Semkovo.Web.Infrastructure.Filters;
using Semkovo.Web.Models.Comments;
using System.Threading.Tasks;

using static Semkovo.Web.WebConstants;

namespace Semkovo.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService comments;
        private readonly UserManager<User> userManager;

        public CommentsController(ICommentService comments, UserManager<User> userManager)
        {
            this.comments = comments;
            this.userManager = userManager;
        }

        public IActionResult Create([FromQuery]int? articleId, [FromQuery]int? parentCommentId)
        {
            if ((articleId == null && parentCommentId == null) || (articleId != null && parentCommentId != null))
            {
                return BadRequest();
            }

            var model = new CommentCreateViewModel
            {
                ArticleId = articleId,
                ParentCommentId = parentCommentId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(CommentCreateViewModel model)
        {
            var userId = this.userManager.GetUserId(User);

            await this.comments.CreateAsync(userId, model.Content, model.ArticleId, model.ParentCommentId);

            if (model.ArticleId == null)
            {
                model.ArticleId = await this.comments.GetArticleId(model.ParentCommentId.Value);
            }

            TempData.AddSuccessMessage($"Comment created successfully!");

            return RedirectToAction("Details", "Articles", new { id = model.ArticleId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.userManager.GetUserId(User);
            var memeAuthorId = await this.comments.GetAuthorId(id);
            if (memeAuthorId != userId && !User.IsInRole(AdministratorRole))
            {
                return BadRequest();
            }

            var memeId = await this.comments.GetArticleId(id);

            if (memeId == null)
            {
                return BadRequest();
            }

            await this.comments.Delete(id);

            return RedirectToAction("Details", "Articles", new { id = memeId });
        }
    }
}
