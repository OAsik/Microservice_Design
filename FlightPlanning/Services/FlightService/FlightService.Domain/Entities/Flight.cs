using FlightService.Domain.Common;

namespace FlightService.Domain.Entities
{
    public class Flight : EntityBase
    {
        public string FlightNumber { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public bool HasScheduled { get; set; }

        public int? CaptainId { get; set; }

        public int? CoPilotId { get; set; }

        public string SeniorCrewId { get; set; }

        public string Crew1Id { get; set; }

        public string Crew2Id { get; set; }

        public string Crew3Id { get; set; }
    }
}