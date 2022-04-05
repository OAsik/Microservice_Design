using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using CrewService.Domain.Entities;
using CrewService.Application.Contracts.Persistence;

namespace CrewService.Application.Features.Commands.UpdateCrew
{
    public class UpdateCrewCommandHandler : IRequestHandler<UpdateCrewCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ICrewRepository _crewRepository;

        public UpdateCrewCommandHandler(IMapper mapper, ICrewRepository crewRepository)
        {
            _mapper = mapper;
            _crewRepository = crewRepository;
        }

        public async Task<bool> Handle(UpdateCrewCommand request, CancellationToken cancellationToken)
        {
            var crewToUpdate = await _crewRepository.GetSingleCrew(request.EmployeeNumber);

            if (crewToUpdate == null)
            {
                throw new Exception("Respective staff cannot be found!");
            }

            _mapper.Map(request, crewToUpdate, typeof(UpdateCrewCommand), typeof(Crew));

            return await _crewRepository.UpdateCrew(crewToUpdate);
        }
    }
}