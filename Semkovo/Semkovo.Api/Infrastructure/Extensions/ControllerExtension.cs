using Microsoft.AspNetCore.Mvc;

namespace Semkovo.Web.Infrastructure.Extensions
{
    public static class ControllerExtension
    {
        public static IActionResult ViewOrNotFound(this Controller controller, object model)
        {
            if (model == null)
            {
                return controller.NotFound();
            }

            return controller.View(model);
        }
    }
}
