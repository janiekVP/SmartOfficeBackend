using AutoMapper;
using SensorData.Dtos;
using SensorData.models;

namespace SensorData.Mapping
{
    public class SensorDataProfile : Profile
    {
        public SensorDataProfile()
        {
            // Entity -> Read DTO
            CreateMap<SensorDataModel, SensorDataReadDto>();

            // Create DTO -> Entity
            CreateMap<SensorDataCreateDto, SensorDataModel>();
        }
    }
}