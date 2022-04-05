using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pilot.Application.Features.Models;
using Pilot.Application.Contracts.Persistence;

namespace Pilot.Application.Features.Queries.GetPilots
{
    public class GetPilotsQueryHandler : IRequestHandler<GetPilotsQuery, List<PilotModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPilotRepository _pilotRepository;

        public GetPilotsQueryHandler(IMapper mapper, IPilotRepository pilotRepository)
        {
            _mapper = mapper;
            _pilotRepository = pilotRepository;
        }

        public async Task<List<PilotModel>> Handle(GetPilotsQuery request, CancellationToken cancellationToken)
        {
            var pilots = await _pilotRepository.GetPilots();

            return _mapper.Map<List<PilotModel>>(pilots);
        }
    }
}