using InfoMovies.Mappings;

namespace InfoMovies.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination ProjectNullable<TSource, TDestination>(
            this Mapping<TSource, TDestination> mapping, TSource value)
            where TSource : class
            where TDestination : class
        {
            return value != null ? mapping.Project(value) : null;
        }
    }
}