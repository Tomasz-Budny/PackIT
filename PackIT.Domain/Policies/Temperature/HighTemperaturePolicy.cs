using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature
{
    public class HighTemperaturePolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        {
            return new List<PackingItem>
            {
                new("Summer hat", 1)
            };
        }

        public bool IsApplicable(PolicyData data)
        {
            return data.Temperature < 25D;
        }
    }
}
