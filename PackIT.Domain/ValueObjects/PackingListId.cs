using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects
{
    public record PackingListId
    {
        public Guid Value { get; }

        public PackingListId(Guid value)
        { 
            if(Value == Guid.Empty)
            {
                throw new EmptyPackingListIdException();
            }
            Value = value;
        }


        public static implicit operator Guid(PackingListId packingListName) => packingListName.Value;

        public static implicit operator PackingListId(Guid packingListName) => new(packingListName);
    }
}
