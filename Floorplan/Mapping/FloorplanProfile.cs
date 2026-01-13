using AutoMapper;
using Floorplan.Dtos;
using Floorplan.models;

namespace Floorplan.Mapping
{
    public class FloorplanProfile : Profile
    {
        public FloorplanProfile()
        {
            // Entity -> Read DTO
            CreateMap<FloorplanModel, FloorplanReadDto>()
                .ForMember(
                    dest => dest.ImageBase64,
                    opt => opt.MapFrom(src =>
                        src.Image != null ? Convert.ToBase64String(src.Image) : null
                    )
                )
                .ForMember(
                    dest => dest.ImageContentType,
                    opt => opt.MapFrom(src => src.ImageContentType)
                );
            
            // Create DTO -> Entity
            CreateMap<FloorplanCreateDto, FloorplanModel>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.ImageContentType, opt => opt.Ignore());

        }
    }
}