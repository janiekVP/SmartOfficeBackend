using AutoMapper;
using POISensor.Dtos;
using POISensor.models;

namespace POISensor.Mapping
{
    public class POISensorProfile : Profile
    {
        public POISensorProfile()
        {
            // Entity -> Read DTO
            CreateMap<POISensorModel, POISensorReadDto>();

            // Create DTO -> Entity
            CreateMap<POISensorCreateDto, POISensorModel>();
        }
    }
}