using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.SharedAbstractions.Commands;

namespace PackIT.Application.Commands.Handlers
{
    public class AddPackingItemHandler : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _repository;


        public AddPackingItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(AddPackingItem command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList == null)
            {
                throw new PackingListNotFoundException(command.Name);
            }

            var packingItem = new PackingItem(command.Name, command.Quantity);
            packingList.AddItem(packingItem);

            await _repository.UpdateAsync(packingList);
        }
    }
}
