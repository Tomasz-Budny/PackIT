using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Domain.Repositories;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.Queries;
using PackIT.SharedAbstractions.Queries;

namespace PackIT.Application.Queries.Handlers
{
    internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {
        private readonly DbSet<PackingListReadModel> _packingList;

        public GetPackingListHandler(ReadDbContext context)
        {
            _packingList = context.PackingLists;
        }

        public Task<PackingListDto> HandleAsync(GetPackingList query)
        {
            return _packingList
                    .Include(pl => pl.Items)
                    .Where(pl => pl.Id == query.Id)
                    .Select(pl => pl.AsDto())
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
        }
    }
}
