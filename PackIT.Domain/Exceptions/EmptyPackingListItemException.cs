using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class EmptyPackingListItemException : PackItException
    {
        public EmptyPackingListItemException() : base("Packing item name cannot be empty!")
        {
        }
    }
}
