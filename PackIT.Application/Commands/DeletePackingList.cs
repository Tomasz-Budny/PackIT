using PackIT.SharedAbstractions.Commands;

namespace PackIT.Application.Commands
{
    public record DeletePackingList(Guid PackingListId, string Name): ICommand;
}
