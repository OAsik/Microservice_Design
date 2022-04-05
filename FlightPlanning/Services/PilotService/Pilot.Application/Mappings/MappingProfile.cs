using AutoMapper;
using Pilot.Application.Features.Models;
using PilotEntity = Pilot.Domain.Entities.Pilot;
using Pilot.Application.Features.Commands.InsertPilot;
using Pilot.Application.Features.Commands.UpdatePilot;

namespace Pilot.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PilotEntity, PilotModel>().ReverseMap();
            CreateMap<PilotEntity, InsertPilotCommand>().ReverseMap();
            CreateMap<PilotEntity, UpdatePilotCommand>().ReverseMap();
        }
    }
}