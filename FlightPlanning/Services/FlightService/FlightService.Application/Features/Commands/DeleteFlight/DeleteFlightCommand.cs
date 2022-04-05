using MediatR;

namespace FlightService.Application.Features.Commands.DeleteFlight
{
    public class DeleteFlightCommand : IRequest
    {
        public string FlightNumber { get; set; }

        public DeleteFlightCommand(string flightNumber)
        {
            FlightNumber = flightNumber;
        }
    }
}