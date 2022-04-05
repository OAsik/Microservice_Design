using MediatR;
using System.Collections.Generic;
using CrewService.Application.Features.Queries.Models;

namespace CrewService.Application.Features.Queries.GetCrews
{
    public class GetCrewQuery : IRequest<List<CrewModel>>
    {

    }
}