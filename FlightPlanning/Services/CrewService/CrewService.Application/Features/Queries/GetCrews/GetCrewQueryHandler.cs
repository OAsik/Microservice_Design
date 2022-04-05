using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using CrewService.Application.Contracts.Persistence;
using CrewService.Application.Features.Queries.Models;

namespace CrewService.Application.Features.Queries.GetCrews
{
    public class GetCrewQueryHandler : IRequestHandler<GetCrewQuery, List<CrewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICrewRepository _crewRepository;

        public GetCrewQueryHandler(IMapper mapper, ICrewRepository crewRepository)
        {
            _mapper = mapper;
            _crewRepository = crewRepository;
        }

        public async Task<List<CrewModel>> Handle(GetCrewQuery request, CancellationToken cancellationToken)
        {
            var crews = await _crewRepository.GetCrews();

            return _mapper.Map<List<CrewModel>>(crews);
        }
    }
}