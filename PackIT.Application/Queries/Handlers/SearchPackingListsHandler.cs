using PackIT.Application.DTO;
using PackIT.SharedAbstractions.Queries;

namespace PackIT.Application.Queries.Handlers
{
    public class SearchPackingListsHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
    {
        public Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
        {

        }
    }
}
