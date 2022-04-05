using AutoMapper;
using Pilot.Application.Features.Models;
using Pilot.Application.Features.Commands.UpdatePilot;

namespace Pilot.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PilotModel, UpdatePilotCommand>().ReverseMap();
        }
    }
}