using BookCart.Application.Common.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BookCart.Application.Common.Mappings
{
    public static class MappingExtensions
    {
        //Extension method for IQueryable to implement pagination.
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);
    }
}