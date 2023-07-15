using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender
{
    internal class MaleGenderPolicy: IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        {
            return new List<PackingItem>()
            {
                new("Beer", 1),
                new("Kozel", 20),
                new("Harnaś", 10),
            };
        }

        public bool IsApplicable(PolicyData data)
        {
            return data.Gender is Consts.Gender.Male;
        }
    }
}
