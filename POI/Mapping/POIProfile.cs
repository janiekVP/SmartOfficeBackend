using AutoMapper;
using POI.Dtos;
using POI.models;

namespace POI.Mapping
{
    public class POIProfile : Profile
    {
        public POIProfile()
        {
            // Entity -> Read DTO
            CreateMap<POIModel, POIReadDto>();

            // Create DTO -> Entity
            CreateMap<POICreateDto, POIModel>();
        }
    }
}