using AutoMapper;

namespace API.Profiles
{
    public abstract class BaseProfile : Profile
    {
        public BaseProfile()
        {
            Mapper();
        }
        public abstract void Mapper();
    }
}