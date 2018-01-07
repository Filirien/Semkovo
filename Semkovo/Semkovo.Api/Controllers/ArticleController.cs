using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Semkovo.Data.Models;
using Semkovo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semkovo.Web.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService articles;
        private UserManager<User> userManager;

        public ArticleController(IArticleService articles, UserManager<User> userManager)
        {
            this.articles = articles;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All(int page = 1)
            => this.View();
    }
}
