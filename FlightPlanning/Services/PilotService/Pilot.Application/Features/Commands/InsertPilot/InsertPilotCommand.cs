using MediatR;

namespace Pilot.Application.Features.Commands.InsertPilot
{
    public class InsertPilotCommand : IRequest<bool>
    {
        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsCaptain { get; set; }
    }
}