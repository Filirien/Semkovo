using Microsoft.AspNetCore.Mvc;
using Semkovo.Services;
using Semkovo.Web.Areas.Events.Controllers;
using System.Threading.Tasks;

namespace Semkovo.Web.Controllers
{
    public class UsersController : Controller
    {
        private IUserService users;

        public UsersController(IUserService users)
        {
            this.users = users;
        }

        public async Task<IActionResult> Join(string userName, int eventId)
        {
            var canBeJoined = await this.users.JoinAsync(userName, eventId);

            if (!canBeJoined)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(EventsController.Details), new { Area = "Events", Controller = "Events", id = eventId});
        }

        public async Task<IActionResult> SignOut(string userName, int eventId)
        {
            var canBeSignedOut = await this.users.SignOutAsync(userName, eventId);

            if (!canBeSignedOut)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(EventsController.All), new { Area = "Events", Controller = "Events" });
        }
    }
}
