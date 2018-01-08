using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Semkovo.Data.Models;
using Semkovo.Services;
using Semkovo.Services.Models;
using Semkovo.Web.Infrastructure.Extensions;
using Semkovo.Web.Infrastructure.Filters;
using Semkovo.Web.Models.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Semkovo.Web.WebConstants;

namespace Semkovo.Web.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {
        private IArticleService articles;
        private UserManager<User> userManager;

        public ArticlesController(IArticleService articles, UserManager<User> userManager)
        {
            this.articles = articles;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(int page = 1)
            => this.View(await this.articles.AllAsync(page));

        public IActionResult Add()
            => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Add(ArticleCreateViewModel model)
        {
            var userId = this.userManager.GetUserId(User);

            await this.articles.CreateAsync(userId, model.Title, model.Content);

            TempData.AddSuccessMessage($"Article created successfully!");

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details([FromRoute]int id)
            => this.ViewOrNotFound(await this.articles.ByIdAsync<ArticleDetailsServiceModel>(id));

        public async Task<IActionResult> Edit(int id)
        {
            var userId = this.userManager.GetUserId(User);
            var memeAuthorId = this.articles.GetAuthorId(id);
            if (memeAuthorId != userId && !User.IsInRole(AdministratorRole))
            {
                return BadRequest();
            }

            return View(await this.articles.ByIdAsync<ArticleEditServiceModel>(id));
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, ArticleEditServiceModel model)
        {
            var userId = this.userManager.GetUserId(User);
            var memeAuthorId = this.articles.GetAuthorId(id);
            if (memeAuthorId != userId && !User.IsInRole(AdministratorRole))
            {
                return BadRequest();
            }

            await this.articles.EditAsync(id, model.Title, model.Content);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var userId = this.userManager.GetUserId(User);
            var memeAuthorId = this.articles.GetAuthorId(id);
            if (memeAuthorId != userId && !User.IsInRole(AdministratorRole))
            {
                return BadRequest();
            }
            await this.articles.DeleteAsync(id);

            return this.RedirectToAction(nameof(All));
        }
    }
}
