using MediatR;
using System.Collections.Generic;
using FlightService.Application.Features.Models;

namespace FlightService.Application.Features.Queries.GetUnscheduledFlights
{
    public class GetUnscheduledFlightsQuery : IRequest<List<FlightModel>>
    {

    }
}