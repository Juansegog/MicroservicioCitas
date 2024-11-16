using AutoMapper;

public class GenericMapperService
{
    private readonly IMapper _mapper;

    public GenericMapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return _mapper.Map<TDestination>(source);
    }

    public List<TDestination> MapList<TSource, TDestination>(List<TSource> source)
    {
        return _mapper.Map<List<TDestination>>(source);
    }

    public List<TDestination> MapListFromObject<TDestination>(List<object> source)
    {
        var result = new List<TDestination>();
        foreach (var item in source)
        {
            result.Add(_mapper.Map<TDestination>(item));
        }
        return result;
    }
}
