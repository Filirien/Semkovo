using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Semkovo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Semkovo.Services;

namespace Semkovo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            => this.View();

        public IActionResult Error()
            => this.View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        
    }
}
