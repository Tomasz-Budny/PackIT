using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.SharedAbstractions.Commands;

namespace PackIT.Application.Commands.Handlers
{
    public class PackItemHandler : ICommandHandler<PackItem>
    {
        private readonly IPackingListRepository _repository;


        public PackItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(PackItem command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList == null)
            {
                throw new PackingListNotFoundException(command.Name);
            }
            packingList.PackItem(command.Name);

            await _repository.UpdateAsync(packingList);
        }
    }
}
