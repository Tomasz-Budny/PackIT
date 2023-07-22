﻿using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF.Contexts;

namespace PackIT.Infrastructure.EF.Services
{
    internal sealed class PostgresPackingListReadService : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingList;

        public PostgresPackingListReadService(ReadDbContext context)
        {
            _packingList = context.PackingLists;
        }

        public Task<bool> ExistsByNameAsync(string name)
        {
            return _packingList.AnyAsync(pl => pl.Name == name);
        }
    }
}