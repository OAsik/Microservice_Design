using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pilot.Application.Features.Models;
using Pilot.Application.Contracts.Persistence;

namespace Pilot.Application.Features.Queries.FindUnscheduledPilots
{
    public class FindUnscheduledPilotsQueryHandler : IRequestHandler<FindUnscheduledPilotsQuery, List<PilotModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPilotRepository _pilotRepository;

        public FindUnscheduledPilotsQueryHandler(IMapper mapper, IPilotRepository pilotRepository)
        {
            _mapper = mapper;
            _pilotRepository = pilotRepository;
        }

        public async Task<List<PilotModel>> Handle(FindUnscheduledPilotsQuery request, CancellationToken cancellationToken)
        {
            var freePilots = await _pilotRepository.FindUnscheduledPilots();

            return _mapper.Map<List<PilotModel>>(freePilots);
        }
    }
}