using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Semkovo.Data.Models;
using Semkovo.Services;
using Semkovo.Web.Areas.Events.Models;
using System.Threading.Tasks;
using Semkovo.Web.Infrastructure.Extensions;

namespace Semkovo.Web.Areas.Events.Controllers
{
    public class EventsController : BaseController
    {
        private IEventService events;
        private UserManager<User> userManager;

        public EventsController(IEventService events, UserManager<User> userManager)
        {
            this.events = events;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var creatorId = this.userManager.GetUserId(User);

            var eventId = await this.events
                .CreateAsync(
                    model.Name,
                    model.StartDate,
                    model.EndDate,
                    creatorId,
                    model.Limit
                );

            TempData.AddSuccessMessage($"Event {model.Name} is created succesfully.");

            return RedirectToAction(nameof(Details), new { id = eventId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var eventDetails = await this.events.DetailsAsync(id);

            if (eventDetails == null)
            {
                return BadRequest();
            }

            return View(eventDetails);
        }
    }
}
