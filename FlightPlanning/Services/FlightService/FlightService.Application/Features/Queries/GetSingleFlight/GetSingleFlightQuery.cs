using MediatR;
using FlightService.Application.Features.Models;

namespace FlightService.Application.Features.Queries.GetSingleFlight
{
    public class GetSingleFlightQuery : IRequest<FlightModel>
    {
        public string FlightNumber { get; set; }

        public GetSingleFlightQuery(string flightNumber)
        {
            FlightNumber = flightNumber;
        }
    }
}