using MediatR;

namespace Pilot.Application.Features.Commands.UpdatePilot
{
    public class UpdatePilotCommand : IRequest<bool>
    {
        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsCaptain { get; set; }

        public bool HasSchedule { get; set; }
    }
}