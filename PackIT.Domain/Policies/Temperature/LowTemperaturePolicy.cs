using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature
{
    public class LowTemperaturePolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        {
            return new List<PackingItem>
            {
                new("Winter hat", 1)
            };
        }

        public bool IsApplicable(PolicyData data)
        {
            return data.Temperature < 10D;
        }
    }
}
