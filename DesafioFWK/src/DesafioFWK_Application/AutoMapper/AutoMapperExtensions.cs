using AutoMapper;
using System.Collections.Generic;

namespace DesafioFWK_Application.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static List<TOut> Map<TIn, TOut>(this List<TIn> input, IMapper mapper)
            => new List<TOut>(mapper.Map<IEnumerable<TIn>, IEnumerable<TOut>>(input));
    }
}
