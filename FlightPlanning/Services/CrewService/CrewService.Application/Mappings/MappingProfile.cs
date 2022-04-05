using AutoMapper;
using CrewService.Domain.Entities;
using CrewService.Application.Features.Queries.Models;
using CrewService.Application.Features.Commands.InsertCrew;
using CrewService.Application.Features.Commands.UpdateCrew;

namespace CrewService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Crew, CrewModel>().ReverseMap();
            CreateMap<Crew, InsertCrewCommand>().ReverseMap();
            CreateMap<Crew, UpdateCrewCommand>().ReverseMap();
        }
    }
}