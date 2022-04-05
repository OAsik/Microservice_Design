using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using FlightService.Domain.Entities;
using FlightService.Application.Contracts.Persistence;

namespace FlightService.Application.Features.Commands.UpdateFlight
{
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand>
    {
        private readonly IMapper _mapper;
        private readonly IFlightEFRepository _commandRepository;
        private readonly IFlightDapperRepository _queryRepository;

        public UpdateFlightCommandHandler(IMapper mapper, IFlightEFRepository commandRepository, IFlightDapperRepository queryRepository)
        {
            _mapper = mapper;
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<Unit> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var flightToUpdate = await _queryRepository.GetSingleFlight(request.FlightNumber);

            if (flightToUpdate == null)
            {
                throw new Exception("Respective flight cannot be found!");
            }

            _mapper.Map(request, flightToUpdate, typeof(UpdateFlightCommand), typeof(Flight));

            await _commandRepository.UpdateFlight(flightToUpdate);

            //Even if your repository methods do not return anything, Mediator's Handle methods expect to return something. In these cases we return Unit.Value
            return Unit.Value;
        }
    }
}