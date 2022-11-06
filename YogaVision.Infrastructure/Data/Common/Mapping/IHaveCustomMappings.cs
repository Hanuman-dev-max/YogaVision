namespace YogaVision.Infrastructure.Data.Common.Mapping
{
    using AutoMapper;
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
