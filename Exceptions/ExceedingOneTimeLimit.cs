namespace ReadyMadeATMBackend.Exceptions
{
    [Serializable]
    internal class ExceedingOneTimeLimit : Exception
    {
        public ExceedingOneTimeLimit()
        {
        }

        public ExceedingOneTimeLimit(string? message) : base(message)
        {
        }

        public ExceedingOneTimeLimit(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}