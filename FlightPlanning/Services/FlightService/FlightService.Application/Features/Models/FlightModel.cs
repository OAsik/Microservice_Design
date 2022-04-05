using System;

namespace FlightService.Application.Features.Models
{
    public class FlightModel
    {
        public int Id { get; set; }

        public string FlightNumber { get; set; }

        public bool IsActive { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public bool HasScheduled { get; set; }

        public int CaptainId { get; set; }

        public int CoPilotId { get; set; }

        public string SeniorCrewId { get; set; }

        public string Crew1Id { get; set; }

        public string Crew2Id { get; set; }

        public string Crew3Id { get; set; }
    }
}