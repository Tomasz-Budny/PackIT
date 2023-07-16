using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.SharedAbstractions.Commands;

namespace PackIT.Application.Commands.Handlers
{
    public class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _repository;


        public RemovePackingItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(RemovePackingItem command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList == null)
            {
                throw new PackingListNotFoundException(command.Name);
            }

            packingList.RemoveItem(command.Name);

            await _repository.UpdateAsync(packingList);
        }
    }
}
