namespace Semkovo.Data.Models
{
    public class UserEvents
    {
        public string ParticipantId { get; set; }

        public User Participant { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
