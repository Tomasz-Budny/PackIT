using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    internal class InvalidTemperatureException : PackItException
    {
        public double Value { get; }

        public InvalidTemperatureException(double value) : base($"Value {value} is invalid temperature.")
        {
            Value = value;
        }
    }
}
