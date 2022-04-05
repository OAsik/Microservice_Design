using MediatR;

namespace Pilot.Application.Features.Commands.DeletePilot
{
    public class DeletePilotCommand : IRequest<bool>
    {
        public string EmployeeNumber { get; set; }
    }
}