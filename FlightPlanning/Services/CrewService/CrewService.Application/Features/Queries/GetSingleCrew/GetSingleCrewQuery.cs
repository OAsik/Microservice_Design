using MediatR;
using CrewService.Application.Features.Queries.Models;

namespace CrewService.Application.Features.Queries.GetSingleCrew
{
    public class GetSingleCrewQuery : IRequest<CrewModel>
    {
        public string EmployeeNumber { get; set; }

        public GetSingleCrewQuery(string employeeNumber)
        {
            EmployeeNumber = employeeNumber;
        }
    }
}