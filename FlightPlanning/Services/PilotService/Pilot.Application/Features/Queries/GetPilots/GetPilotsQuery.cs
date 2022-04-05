using MediatR;
using System.Collections.Generic;
using Pilot.Application.Features.Models;

namespace Pilot.Application.Features.Queries.GetPilots
{
    public class GetPilotsQuery : IRequest<List<PilotModel>>
    {

    }
}