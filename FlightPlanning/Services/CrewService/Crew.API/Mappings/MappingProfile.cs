using AutoMapper;
using CrewService.Application.Features.Queries.Models;
using CrewService.Application.Features.Commands.UpdateCrew;

namespace Crew.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CrewModel, UpdateCrewCommand>().ReverseMap();
        }
    }
}