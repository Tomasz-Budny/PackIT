using PackIT.SharedAbstractions.Commands;

namespace PackIT.Application.Commands
{
    public record RemovePackingItem(Guid PackingListId, string Name): ICommand;
}
