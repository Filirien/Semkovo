using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Semkovo.Data.Models;
using Semkovo.Services;
using Semkovo.Web.Areas.Events.Models;
using System.Threading.Tasks;
using Semkovo.Web.Infrastructure.Extensions;
using Semkovo.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Semkovo.Web.Models.UserViewModels;

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

        [Authorize]
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

            if (eventId == 0)
            {
                TempData.AddErrorMessage($"Event start date should be equals ot greater than today, end date should be bigger than start date.");

                return View(model);
            }

            TempData.AddSuccessMessage($"Event {model.Name} is created succesfully.");

            return RedirectToAction(nameof(Details), new { id = eventId });
        }

        public async Task<IActionResult> All()
        {
            // Making is choined logic work

            var events = await this.events.AllAsync();

            return View(new UserViewModel
            {
                Events = events
            });
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

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var eventExist = await this.events.ExistsAsync(this.userManager.GetUserId(User), id);

            if (!eventExist)
            {
                return NotFound();
            }

            var ev = await this.events.DetailsAsync(id);

            return View(new EventDetailsServiceModel
            {
                Name = ev.Name,
                StartDate = ev.StartDate,
                EndDate = ev.EndDate,
                Limit = ev.Limit
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventDetailsServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var updated = await this.events
                .EditAsync(
                this.userManager.GetUserId(User),
                id,
                model.Name,
                model.StartDate,
                model.EndDate,
                model.Limit);

            if (!updated)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.events.DeleteAsync(id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
