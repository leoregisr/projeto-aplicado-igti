using AutoMapper;
using PA.Common.Extensions;

namespace PA.Common.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            foreach (var map in SingletonMapper.Maps)
            {
                CreateMap(map.Item1, map.Item2).IgnoreAllNonExisting();
            }
        }
    }
}