using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightService.Application.Features.Models;
using FlightService.Application.Contracts.Persistence;

namespace FlightService.Application.Features.Queries.GetUnscheduledFlights
{
    public class GetUnscheduledFlightsQueryHandler : IRequestHandler<GetUnscheduledFlightsQuery, List<FlightModel>>
    {
        private readonly IMapper _mapper;
        private readonly IFlightDapperRepository _repository;

        public GetUnscheduledFlightsQueryHandler(IMapper mapper, IFlightDapperRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<FlightModel>> Handle(GetUnscheduledFlightsQuery request, CancellationToken cancellationToken)
        {
            var unscheduledFlights = await _repository.GetUnscheduledFlights();

            return _mapper.Map<List<FlightModel>>(unscheduledFlights);
        }
    }
}