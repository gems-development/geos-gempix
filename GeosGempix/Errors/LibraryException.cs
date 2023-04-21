namespace GeosGempix.Errors
{
    internal class LibraryException : Exception
    {
        public ErrorCode Code { get; }

        public LibraryException(ErrorCode code, String message) : base (message)
        {
            Code = code;
        }

    }
}
