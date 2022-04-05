using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FlightService.Application.Contracts.Persistence;

namespace FlightService.Application.Features.Commands.DeleteFlight
{
    public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand>
    {
        private readonly IFlightEFRepository _commandRepository;
        private readonly IFlightDapperRepository _queryRepository;

        public DeleteFlightCommandHandler(IFlightEFRepository commandRepository, IFlightDapperRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<Unit> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            var flightToGoPassive = await _queryRepository.GetSingleFlight(request.FlightNumber);

            if (flightToGoPassive == null)
            {
                throw new Exception("Respective flight cannot be found!");
            }

            await _commandRepository.DeleteFlight(flightToGoPassive);

            //Even if your repository methods do not return anything, Mediator's Handle methods expect to return something. In these cases we return Unit.Value
            return Unit.Value;
        }
    }
}