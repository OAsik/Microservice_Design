using MediatR;
using System.Collections.Generic;
using FlightService.Application.Features.Models;

namespace FlightService.Application.Features.Queries.GetFlights
{
    public class GetFlightsQuery : IRequest<List<FlightModel>>
    {

    }
}