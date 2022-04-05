using MediatR;
using System.Collections.Generic;
using CrewService.Application.Features.Queries.Models;

namespace CrewService.Application.Features.Queries.FindSeniorStaff
{
    public class FindSeniorStaffQuery : IRequest<List<CrewModel>>
    {

    }
}