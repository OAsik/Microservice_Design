using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Pilot.Application.Contracts.Persistence;
using PilotEntity = Pilot.Domain.Entities.Pilot;

namespace Pilot.Application.Features.Commands.UpdatePilot
{
    public class UpdatePilotCommandHandler : IRequestHandler<UpdatePilotCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPilotRepository _pilotRepository;

        public UpdatePilotCommandHandler(IMapper mapper, IPilotRepository pilotRepository)
        {
            _mapper = mapper;
            _pilotRepository = pilotRepository;
        }

        public async Task<bool> Handle(UpdatePilotCommand request, CancellationToken cancellationToken)
        {
            var pilotToUpdate = await _pilotRepository.GetSinglePilot(request.EmployeeNumber);

            if (pilotToUpdate == null)
            {
                throw new Exception("Respective staff cannot be found!");
            }

            _mapper.Map(request, pilotToUpdate, typeof(UpdatePilotCommand), typeof(PilotEntity));

            return await _pilotRepository.UpdatePilot(pilotToUpdate);
        }
    }
}