using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Semkovo.Web.Models;

namespace Semkovo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            => this.View();

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Error()
            => this.View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });        
    }
}
