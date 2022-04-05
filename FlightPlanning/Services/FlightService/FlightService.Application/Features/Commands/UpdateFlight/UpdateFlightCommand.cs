using MediatR;

namespace FlightService.Application.Features.Commands.UpdateFlight
{
    public class UpdateFlightCommand : IRequest
    {
        public string FlightNumber { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public bool HasScheduled { get; set; }
    }
}