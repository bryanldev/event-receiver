using API.Models;
using Domain.Entities.SensorEventAggregate;

namespace API.Profiles
{
    public class SensorEventProfile : BaseProfile
    {
        public override void Mapper()
        {
            CreateMap<SensorEvent, SensorEventResponseModel>()
                .ForMember(m => m.Data, opt => opt.MapFrom(prop => prop.Data.ToString()))
                .ForMember(m => m.Timestamp, opt => opt.MapFrom(prop => prop.Timestamp.ToString()))
                .ForMember(m => m.Tag, opt => opt.MapFrom(prop => prop.Tag.ToString()))
                .ForMember(m => m.Status, opt => opt.MapFrom(prop => prop.Status));

            CreateMap<SensorEventRequestModel, SensorEvent>()
                .ConstructUsing(m => new SensorEvent(
                    new Timestamp(m.Timestamp),
                    new Tag(m.Tag),
                    new SensorData(m.Data)));

            CreateMap<string, Tag>().ConstructUsing(s => new Tag(s));
            CreateMap<string, Timestamp>().ConstructUsing(s => new Timestamp(s));
            CreateMap<string, SensorData>().ConstructUsing(s => new SensorData(s));
        }
    }
}