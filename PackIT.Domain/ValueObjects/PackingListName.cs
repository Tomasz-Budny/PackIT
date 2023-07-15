using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects
{
    public record PackingListName
    {
        public string Value { get; }

        public PackingListName(string value)
        {

            if(string.IsNullOrEmpty(value))
            {
                throw new EmptyPackingListNameException();
            }

            Value = value;
        }

        public static implicit operator string(PackingListName packingListName) => packingListName.Value;

        public static implicit operator PackingListName(string packingListName) => new(packingListName);
    }
}
