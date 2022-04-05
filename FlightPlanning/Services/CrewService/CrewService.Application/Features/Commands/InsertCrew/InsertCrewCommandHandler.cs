using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using CrewService.Domain.Entities;
using CrewService.Application.Contracts.Persistence;

namespace CrewService.Application.Features.Commands.InsertCrew
{
    public class InsertCrewCommandHandler : IRequestHandler<InsertCrewCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly ICrewRepository _crewRepository;

        public InsertCrewCommandHandler(IMapper mapper, ICrewRepository crewRepository)
        {
            _mapper = mapper;
            _crewRepository = crewRepository;
        }

        public Task<string> Handle(InsertCrewCommand request, CancellationToken cancellationToken)
        {
            var crewEntity = _mapper.Map<Crew>(request);

            return _crewRepository.InsertCrew(crewEntity);
        }
    }
}