using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using FlightService.Domain.Entities;
using FlightService.Application.Features.Models;
using FlightService.Application.Contracts.Persistence;

namespace FlightService.Application.Features.Commands.InsertFlight
{
    public class InsertFlightCommandHandler : IRequestHandler<InsertFlightCommand, FlightModel>
    {
        private readonly IMapper _mapper;
        private readonly IFlightEFRepository _repository;

        public InsertFlightCommandHandler(IMapper mapper, IFlightEFRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<FlightModel> Handle(InsertFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = _mapper.Map<Flight>(request);

            var entity = await _repository.InsertFlight(flight);

            return _mapper.Map<FlightModel>(entity);
        }
    }
}