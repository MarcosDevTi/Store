using AutoMapper;

namespace Store.Application.Automapper
{
    public interface ICustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
