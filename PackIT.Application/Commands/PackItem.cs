using PackIT.SharedAbstractions.Commands;

namespace PackIT.Application.Commands
{
    public record PackItem(Guid PackingListId, string Name): ICommand;
}
