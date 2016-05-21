using AutoMapper;

namespace BTC.Shared.Automapper
{
    public interface IMapConfig
    {
        void ConfigMapToSourse(IMapperConfiguration cfg);
        void ConfigMapToDestination(IMapperConfiguration cfg);
    }
}