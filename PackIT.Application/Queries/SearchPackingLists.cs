using PackIT.Application.DTO;
using PackIT.SharedAbstractions.Queries;

namespace PackIT.Application.Queries
{
    public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
    {
        public string SearchPhrase { get; set; }
    }
}
