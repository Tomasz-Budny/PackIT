using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.SharedAbstractions.Commands;

namespace PackIT.Application.Commands.Handlers
{
    public class DeletePackingListHandler : ICommandHandler<DeletePackingList>
    {
        private readonly IPackingListRepository _repository;


        public DeletePackingListHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeletePackingList command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList == null)
            {
                throw new PackingListNotFoundException(command.Name);
            }

            await _repository.DeleteAsync(packingList);
        }
    }
}
