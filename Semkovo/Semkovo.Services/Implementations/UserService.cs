using Microsoft.EntityFrameworkCore;
using Semkovo.Data;
using Semkovo.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Semkovo.Services.Implementations
{
    public class UserService : IUserService
    {
        private SemkovoDbContext db;

        public UserService(SemkovoDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> JoinAsync(string userName, int eventId)
        {
            var ev = await this.db
                .Events
                .FindAsync(eventId);

            var user = await this.db
                .Users
                .Where(u => u.UserName == userName)
                .FirstOrDefaultAsync();

            if (user == null || ev == null)
            {
                return false;
            }

            if (ev.Participants.Any(e => e.EventId == eventId && e.Participant.UserName == userName))
            {
                return false;
            }

            ev.Participants.Add(new UserEvents
            {
                ParticipantId = user.Id,
                EventId = eventId
            });

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SignOutAsync(string userName, int eventId)
        {
            var userEvent = await this.db
                .UserEvents
                .Where(ue => ue.Participant.UserName == userName && ue.EventId == eventId)
                .FirstOrDefaultAsync();

            if (userEvent == null)
            {
                return false;
            }

            this.db.UserEvents.Remove(userEvent);

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
