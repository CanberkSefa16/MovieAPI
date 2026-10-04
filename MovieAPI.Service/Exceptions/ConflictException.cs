namespace MovieAPI.Service.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message)
        {
            
        }
    }
}