using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    internal class InvalidTravelDaysException : PackItException
    {
        public ushort Days{ get; set; }

        public InvalidTravelDaysException(ushort days) : base($"Value {days} is invalid travel days.")
        {
            Days = days;
        }
    }
}
