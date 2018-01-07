using Semkovo.Services.Models;
using System.Collections.Generic;

namespace Semkovo.Web.Models.UserViewModels
{
    public class UserViewModel
    {
        public IEnumerable<EventListingServiceModel> Events { get; set; }

        public bool IsJoined { get; set; }
    }
}
