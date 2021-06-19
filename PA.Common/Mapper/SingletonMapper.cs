using System;
using System.Collections.Generic;

namespace PA.Common.Mapper
{
    public class SingletonMapper
    {
        public static AutoMapper.IMapper Mapper { get; private set; }
        public static readonly IList<Tuple<Type, Type>> Maps = new List<Tuple<Type, Type>>();


        public SingletonMapper(AutoMapper.IMapper mapper)
        {
            SingletonMapper.Mapper = mapper;
        }
    }
}