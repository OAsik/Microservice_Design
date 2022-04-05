using MediatR;
using FlightService.Application.Features.Models;

namespace FlightService.Application.Features.Commands.InsertFlight
{
    public class InsertFlightCommand : IRequest<FlightModel>
    {
        public string FlightNumber { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public bool HasScheduled { get; set; }
    }
}