using PackIT.Application.DTO;

namespace PackIT.Infrastructure.Queries
{
    internal static class Extensions
    {
        public static PackingListDto AsDto(this PackingListReadModel readModel)
        {
            return new()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Localization = new LocalizationDto()
                {
                    City = readModel.Localization.City,
                    Country = readModel.Localization.Country,
                },
                Items = readModel.Items.Select(x => new PackingItemDto()
                {
                    Name = x.Name,
                    Quantity = x.Quantity,
                    IsPacked = x.IsPacked,
                })
            };
        }
    }
}
