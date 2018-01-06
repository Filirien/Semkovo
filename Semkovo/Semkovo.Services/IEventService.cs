using Semkovo.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semkovo.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventListingServiceModel>> AllAsync(int page = 1);

        Task<EventDetailsServiceModel> DetailsAsync(int id);

        Task<bool> EditAsync(
            int id, 
            string name, 
            DateTime startDate,
            DateTime endDate,
            int limit);

        Task<bool> DeleteAsync(int id);
    }
}
