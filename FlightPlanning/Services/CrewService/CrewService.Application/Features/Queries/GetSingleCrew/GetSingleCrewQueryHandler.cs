using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using CrewService.Application.Contracts.Persistence;
using CrewService.Application.Features.Queries.Models;


namespace CrewService.Application.Features.Queries.GetSingleCrew
{
    public class GetSingleCrewQueryHandler : IRequestHandler<GetSingleCrewQuery, CrewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICrewRepository _crewRepository;

        public GetSingleCrewQueryHandler(IMapper mapper, ICrewRepository crewRepository)
        {
            _mapper = mapper;
            _crewRepository = crewRepository;
        }

        public async Task<CrewModel> Handle(GetSingleCrewQuery request, CancellationToken cancellationToken)
        {
            var crew = await _crewRepository.GetSingleCrew(request.EmployeeNumber);

            return _mapper.Map<CrewModel>(crew);
        }
    }
}