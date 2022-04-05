using MediatR;
using Pilot.Application.Features.Models;

namespace Pilot.Application.Features.Queries.GetSinglePilot
{
    public class GetSinglePilotQuery : IRequest<PilotModel>
    {
        public string EmployeeNumber { get; set; }

        public GetSinglePilotQuery(string employeeNumber)
        {
            EmployeeNumber = employeeNumber;
        }
    }
}
