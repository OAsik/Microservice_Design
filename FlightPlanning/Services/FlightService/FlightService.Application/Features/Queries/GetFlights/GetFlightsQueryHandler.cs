using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightService.Application.Features.Models;
using FlightService.Application.Contracts.Persistence;

namespace FlightService.Application.Features.Queries.GetFlights
{
    public class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, List<FlightModel>>
    {
        private readonly IMapper _mapper;
        private readonly IFlightDapperRepository _repository;

        public GetFlightsQueryHandler(IMapper mapper, IFlightDapperRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<FlightModel>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _repository.GetFlights();

            return _mapper.Map<List<FlightModel>>(flights);
        }
    }
}