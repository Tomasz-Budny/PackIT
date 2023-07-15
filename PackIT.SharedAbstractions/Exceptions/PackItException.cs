namespace PackIT.SharedAbstractions.Exceptions
{
    public abstract class PackItException : Exception
    {
        protected PackItException(string message) : base(message) { }
    }
}
