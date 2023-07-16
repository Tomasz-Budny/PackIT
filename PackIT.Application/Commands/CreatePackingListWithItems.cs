using PackIT.Domain.Consts;
using PackIT.SharedAbstractions.Commands;

namespace PackIT.Application.Commands
{
    // Tutaj nie przeszkadza, że korzystamy z primitive
    public record CreatePackingListWithItems(Guid Id, string Name, ushort Days, Gender Gender, LocalizationWriteModel Localization) : ICommand;

    public record LocalizationWriteModel(string City, string Country);
}
