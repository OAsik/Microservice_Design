using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using FlightService.Application.Features.Models;
using FlightService.Application.Contracts.Persistence;

namespace FlightService.Application.Features.Queries.GetSingleFlight
{
    public class GetSingleFlightQueryHandler : IRequestHandler<GetSingleFlightQuery, FlightModel>
    {
        private readonly IMapper _mapper;
        private readonly IFlightDapperRepository _repository;

        public GetSingleFlightQueryHandler(IMapper mapper, IFlightDapperRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<FlightModel> Handle(GetSingleFlightQuery request, CancellationToken cancellationToken)
        {
            var flight = await _repository.GetSingleFlight(request.FlightNumber);

            return _mapper.Map<FlightModel>(flight);
        }
    }
}