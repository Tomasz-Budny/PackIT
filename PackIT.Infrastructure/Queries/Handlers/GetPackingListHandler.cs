using PackIT.Application.DTO;
using PackIT.Domain.Repositories;
using PackIT.SharedAbstractions.Queries;

namespace PackIT.Application.Queries.Handlers
{
    public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {
        private IPackingListRepository _repository;

        public GetPackingListHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task<PackingListDto> HandleAsync(GetPackingList query)
        {
            var packingList = await _repository.GetAsync(query.Id);
            return packingList?.AsDTO();
        }
    }
}
