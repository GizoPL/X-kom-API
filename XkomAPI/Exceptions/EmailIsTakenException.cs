namespace XkomAPI.Exceptions
{
    public class EmailIsTakenException : System.Exception
    {
        public EmailIsTakenException(string message) : base(message)
        {
            
        }
    }
}