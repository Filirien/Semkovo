using Semkovo.Common.Mapping;
using Semkovo.Data.Models;
using System;
using AutoMapper;
using System.Collections.Generic;

namespace Semkovo.Services.Models
{
    public class EventListingServiceModel : IMapFrom<Event>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string CreatorName { get; set; }

        public List<UserEvents> Participants { get; set; } = new List<UserEvents>();

        public int Limit { get; set; }

        public bool IsJoined { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Event, EventListingServiceModel>()
                .ForMember(c => c.CreatorName, cfg => cfg.MapFrom(n => n.Creator.UserName));
    }
}
