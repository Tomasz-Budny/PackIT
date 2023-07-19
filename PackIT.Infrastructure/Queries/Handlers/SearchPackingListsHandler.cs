using PackIT.Application.DTO;
using PackIT.SharedAbstractions.Queries;

namespace PackIT.Application.Queries.Handlers
{
    public class SearchPackingListsHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListReadModel>>
    {
        public Task<IEnumerable<PackingListReadModel>> HandleAsync(SearchPackingLists query)
        {
            return null;
        }
    }
}
