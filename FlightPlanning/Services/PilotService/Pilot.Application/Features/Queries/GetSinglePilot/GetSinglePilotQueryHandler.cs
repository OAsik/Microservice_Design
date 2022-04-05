using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Pilot.Application.Features.Models;
using Pilot.Application.Contracts.Persistence;

namespace Pilot.Application.Features.Queries.GetSinglePilot
{
    public class GetSinglePilotQueryHandler : IRequestHandler<GetSinglePilotQuery, PilotModel>
    {
        private readonly IMapper _mapper;
        private readonly IPilotRepository _pilotRepository;

        public GetSinglePilotQueryHandler(IMapper mappler, IPilotRepository pilotRepository)
        {
            _mapper = mappler;
            _pilotRepository = pilotRepository;
        }

        public async Task<PilotModel> Handle(GetSinglePilotQuery request, CancellationToken cancellationToken)
        {
            var pilot = await _pilotRepository.GetSinglePilot(request.EmployeeNumber);

            return _mapper.Map<PilotModel>(pilot);
        }
    }
}