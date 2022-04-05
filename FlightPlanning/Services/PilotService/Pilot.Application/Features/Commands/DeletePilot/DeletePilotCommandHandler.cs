using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pilot.Application.Contracts.Persistence;

namespace Pilot.Application.Features.Commands.DeletePilot
{
    public class DeletePilotCommandHandler : IRequestHandler<DeletePilotCommand, bool>
    {
        private readonly IPilotRepository _pilotRepository;

        public DeletePilotCommandHandler(IPilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public async Task<bool> Handle(DeletePilotCommand request, CancellationToken cancellationToken)
        {
            var pilotToGoPassive = await _pilotRepository.GetSinglePilot(request.EmployeeNumber);

            if (pilotToGoPassive == null)
            {
                throw new Exception("Respective staff cannot be found!");
            }

            return await _pilotRepository.DeletePilot(pilotToGoPassive);
        }
    }
}