using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Universal
{
    public class BasicPolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        {
            return new List<PackingItem>()
            {
                new("Toothbrush", 1),
                new("Toothpaste", 1)
            };
        }

        public bool IsApplicable(PolicyData data)
        {
            return true;
        }
    }
}
