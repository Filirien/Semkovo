using Semkovo.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Semkovo.Services
{
    public interface IEventService
    {
        Task<int> CreateAsync(
            string name,
            DateTime StartDate,
            DateTime EndDate,
            string creatorId,
            int limit
            );

        Task<IEnumerable<EventListingServiceModel>> AllAsync(int page = 1);

        Task<EventDetailsServiceModel> DetailsAsync(int eventId);

        Task<bool> EditAsync(
            string creatorId,
            int eventId, 
            string name, 
            DateTime startDate,
            DateTime endDate,
            int limit);

        Task<bool> DeleteAsync(int eventId);

        Task<bool> ExistsAsync(string creatorId, int eventId);
    }
}
