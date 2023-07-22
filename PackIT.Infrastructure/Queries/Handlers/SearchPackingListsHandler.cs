using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.Queries;
using PackIT.SharedAbstractions.Queries;

namespace PackIT.Application.Queries.Handlers
{
    internal sealed class SearchPackingListsHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
    {
        private readonly DbSet<PackingListReadModel> _packingList;

        public SearchPackingListsHandler(ReadDbContext context)
        {
            _packingList = context.PackingLists;
        }
        public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
        {
            var dbQuery = _packingList
                .Include(pl => pl.Items)
                .AsQueryable();

            if(query.SearchPhrase is not null)
            {
                dbQuery = dbQuery.Where(pl => EF.Functions.ILike(pl.Name, $"%{query.SearchPhrase}%"));
            }

            return await dbQuery.Select(pl => pl.AsDto()).AsNoTracking().ToListAsync();
        }
    }
}
