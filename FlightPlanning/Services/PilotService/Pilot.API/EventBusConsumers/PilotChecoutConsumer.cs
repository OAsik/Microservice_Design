using MediatR;
using AutoMapper;
using MassTransit;
using System.Threading.Tasks;
using EventBus.Messages.Events;
using Pilot.Application.Features.Models;
using Pilot.Application.Features.Commands.UpdatePilot;
using Pilot.Application.Features.Queries.GetSinglePilot;

namespace Pilot.API.EventBusConsumers
{
    public class PilotChecoutConsumer : IConsumer<PilotCheckoutEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PilotChecoutConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<PilotCheckoutEvent> context)
        {
            foreach (var employeeNumber in context.Message.EmployeeNumbers)
            {
                var query = new GetSinglePilotQuery(employeeNumber);

                var pilot = await _mediator.Send(query);

                pilot.HasSchedule = context.Message.HasSchedule;

                var updatePilotCommand = new UpdatePilotCommand();

                _mapper.Map(pilot, updatePilotCommand, typeof(PilotModel), typeof(UpdatePilotCommand));

                var result = await _mediator.Send(updatePilotCommand);
            }
        }
    }
}