using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Semkovo.Services.Models;
using Semkovo.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Semkovo.Data.Models;

namespace Semkovo.Services.Implementations
{
    public class EventService : IEventService
    {
        private SemkovoDbContext db;

        public EventService(SemkovoDbContext db)
        {
            this.db = db;
        }

        public async Task<int> CreateAsync(string name, DateTime startDate, DateTime endDate, string creatorId, int limit)
        {
            var creator = await this.db.Users.FindAsync(creatorId);

            //TODO validate dates

            var ev = new Event
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Creator = creator,
                Limit = limit
            };

            this.db.Add(ev);

            await this.db.SaveChangesAsync();

            return ev.Id;
        }

        public async Task<IEnumerable<EventListingServiceModel>> AllAsync(int page = 1)
            => await this.db
                .Events
                .OrderByDescending(e => e.StartDate)
                .ProjectTo<EventListingServiceModel>()
                .ToListAsync();
        
        public async Task<EventDetailsServiceModel> DetailsAsync(int id)
            => await this.db
                .Events
                .Where(e => e.Id == id)
                .ProjectTo<EventDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<bool> EditAsync(
            int id, 
            string name, 
            DateTime startDate, 
            DateTime endDate, 
            int limit)
        {
            var ev = await this.db.Events.FindAsync(id);

            if (ev == null)
            {
                return false;
            }

            ev.Name = name;
            ev.StartDate = startDate;
            ev.EndDate = endDate;
            ev.Limit = limit;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ev = await this.db.Events.FindAsync(id);

            if (ev == null)
            {
                return false;
            }

            this.db.Events.Remove(ev);

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
