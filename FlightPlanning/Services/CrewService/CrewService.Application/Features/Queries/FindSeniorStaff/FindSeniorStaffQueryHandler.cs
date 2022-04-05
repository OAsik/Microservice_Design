using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using CrewService.Application.Contracts.Persistence;
using CrewService.Application.Features.Queries.Models;

namespace CrewService.Application.Features.Queries.FindSeniorStaff
{
    public class FindSeniorStaffQueryHandler : IRequestHandler<FindSeniorStaffQuery, List<CrewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICrewRepository _crewRepository;

        public FindSeniorStaffQueryHandler(IMapper mapper, ICrewRepository crewRepository)
        {
            _mapper = mapper;
            _crewRepository = crewRepository;
        }

        public async Task<List<CrewModel>> Handle(FindSeniorStaffQuery request, CancellationToken cancellationToken)
        {
            var seniorCrews = await _crewRepository.FindSeniorStaff();

            return _mapper.Map<List<CrewModel>>(seniorCrews);
        }
    }
}