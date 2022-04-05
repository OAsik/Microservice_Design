using MediatR;

namespace CrewService.Application.Features.Commands.DeleteCrew
{
    public class DeleteCrewCommand : IRequest<bool>
    {
        public string ID { get; set; }
    }
}