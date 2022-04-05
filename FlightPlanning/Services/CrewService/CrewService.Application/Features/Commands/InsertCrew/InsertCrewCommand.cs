using MediatR;

namespace CrewService.Application.Features.Commands.InsertCrew
{
    public class InsertCrewCommand : IRequest<string>
    {
        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsSenior { get; set; }
    }
}