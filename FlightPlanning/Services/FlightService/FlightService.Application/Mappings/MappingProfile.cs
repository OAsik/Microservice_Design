using AutoMapper;
using FlightService.Domain.Entities;
using FlightService.Application.Features.Models;
using FlightService.Application.Features.Commands.InsertFlight;
using FlightService.Application.Features.Commands.UpdateFlight;
using FlightService.Application.Features.Commands.ScheduleFlight;

namespace FlightService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Flight, FlightModel>().ReverseMap();
            CreateMap<Flight, InsertFlightCommand>().ReverseMap();
            CreateMap<Flight, UpdateFlightCommand>().ReverseMap();
            CreateMap<Flight, UpdateFlightCommand>().ReverseMap();
            CreateMap<Flight, ScheduleFlightCommand>().ReverseMap();
        }
    }
}