using MediatR;
using System.Collections.Generic;
using Pilot.Application.Features.Models;

namespace Pilot.Application.Features.Queries.FindUnscheduledPilots
{
    public class FindUnscheduledPilotsQuery : IRequest<List<PilotModel>>
    {

    }
}