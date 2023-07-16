using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Application.Exceptions
{
    public class PackingListNotFoundException : PackItException
    {
        public PackingListNotFoundException(string name) : base($"Packing list with name {name} was not found.")
        {
        }
    }
}
