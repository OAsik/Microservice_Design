using MediatR;

namespace FlightService.Application.Features.Commands.ScheduleFlight
{
    public class ScheduleFlightCommand : IRequest
    {
        public string FlightNumber { get; set; }

        public string CaptainId { get; set; }

        public string CoPilotId { get; set; }

        public string SeniorCrewId { get; set; }

        public string Crew1Id { get; set; }

        public string Crew2Id { get; set; }

        public string Crew3Id { get; set; }
    }
}