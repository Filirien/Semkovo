using AutoMapper;
using Semkovo.Common.Mapping;
using Semkovo.Data.Models;
using System;

namespace Semkovo.Services.Models
{
    public class EventDetailsServiceModel : IMapFrom<Event>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string CreatorName { get; set; }

        public int Participants { get; set; }

        public int Limit { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Event, EventDetailsServiceModel>()
                .ForMember(c => c.CreatorName, cfg => cfg.MapFrom(n => n.Creator.UserName))
                .ForMember(p => p.Participants, cfg => cfg.MapFrom(pc => pc.Participants.Count));
    }
}