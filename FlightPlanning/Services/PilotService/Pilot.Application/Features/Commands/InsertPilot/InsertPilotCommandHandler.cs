using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Pilot.Application.Contracts.Persistence;
using PilotEntity = Pilot.Domain.Entities.Pilot;

namespace Pilot.Application.Features.Commands.InsertPilot
{
    class InsertPilotCommandHandler : IRequestHandler<InsertPilotCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPilotRepository _pilotRepository;

        public InsertPilotCommandHandler(IMapper mapper, IPilotRepository pilotRepository)
        {
            _mapper = mapper;
            _pilotRepository = pilotRepository;
        }

        public async Task<bool> Handle(InsertPilotCommand request, CancellationToken cancellationToken)
        {
            var pilot = _mapper.Map<PilotEntity>(request);

            return await _pilotRepository.InsertPilot(pilot);
        }
    }
}