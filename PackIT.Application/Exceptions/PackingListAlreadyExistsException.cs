using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Application.Exceptions
{
    internal class PackingListAlreadyExistsException : PackItException
    {
        public PackingListAlreadyExistsException(string name) : base($"Packing list with name: {name} already exists.")
        {
        }
    }
}
