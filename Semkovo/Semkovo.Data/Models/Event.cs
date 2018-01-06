using System;
using System.Collections.Generic;

namespace Semkovo.Data.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public User Creator { get; set; }

        public string CreatorId { get; set; }

        public List<UserEvents> Participants { get; set; } = new List<UserEvents>();

        public int Limit { get; set; }
    }
}
