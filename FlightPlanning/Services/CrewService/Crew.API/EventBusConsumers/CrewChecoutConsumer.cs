using MediatR;
using AutoMapper;
using MassTransit;
using System.Threading.Tasks;
using EventBus.Messages.Events;
using CrewService.Application.Features.Queries.Models;
using CrewService.Application.Features.Commands.UpdateCrew;
using CrewService.Application.Features.Queries.GetSingleCrew;

namespace Crew.API.EventBusConsumers
{
    public class CrewChecoutConsumer : IConsumer<CrewCheckoutEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CrewChecoutConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<CrewCheckoutEvent> context)
        {
            foreach (var employeeNumber in context.Message.EmployeeNumbers)
            {
                var query = new GetSingleCrewQuery(employeeNumber);

                var crew = await _mediator.Send(query);

                crew.HasSchedule = context.Message.HasSchedule;

                var updateCrewCommand = new UpdateCrewCommand();

                _mapper.Map(crew, updateCrewCommand, typeof(CrewModel), typeof(UpdateCrewCommand));

                var result = await _mediator.Send(updateCrewCommand);
            }
        }
    }
}