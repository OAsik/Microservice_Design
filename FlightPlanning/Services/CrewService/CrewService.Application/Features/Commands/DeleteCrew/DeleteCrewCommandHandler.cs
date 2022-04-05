using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CrewService.Application.Contracts.Persistence;

namespace CrewService.Application.Features.Commands.DeleteCrew
{
    public class DeleteCrewCommandHandler : IRequestHandler<DeleteCrewCommand, bool>
    {
        private readonly ICrewRepository _crewRepository;

        public DeleteCrewCommandHandler(ICrewRepository crewRepository)
        {
            _crewRepository = crewRepository;
        }

        public async Task<bool> Handle(DeleteCrewCommand request, CancellationToken cancellationToken)
        {
            var crewToGoPassive = await _crewRepository.GetSingleCrew(request.ID);

            if (crewToGoPassive == null)
            {
                throw new Exception("Respective staff cannot be found!");
            }

            return await _crewRepository.DeleteCrew(crewToGoPassive.Id);
        }
    }
}