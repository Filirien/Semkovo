using System;
using System.ComponentModel.DataAnnotations;

namespace Semkovo.Web.Areas.Events.Models
{
    public class EventCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int Limit { get; set; }
    }
}
