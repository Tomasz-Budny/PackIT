using PackIT.Domain.Consts;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies
{
    public record PolicyData(TravelDays days, Consts.Gender Gender, ValueObjects.Temperature Temperature, Localization Localization);
}
