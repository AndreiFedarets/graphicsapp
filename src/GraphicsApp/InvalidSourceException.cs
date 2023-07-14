namespace GraphicsApp
{
    public class InvalidSourceException : Exception
    {
        public InvalidSourceException(string message)
            : base(message)
        {
        }
        public InvalidSourceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
