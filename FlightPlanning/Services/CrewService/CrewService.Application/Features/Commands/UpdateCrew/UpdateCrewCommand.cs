using MediatR;

namespace CrewService.Application.Features.Commands.UpdateCrew
{
    public class UpdateCrewCommand : IRequest<bool>
    {
        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsSenior { get; set; }

        public bool HasSchedule { get; set; }
    }
}