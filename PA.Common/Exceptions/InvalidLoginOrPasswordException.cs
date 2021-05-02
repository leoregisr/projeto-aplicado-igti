namespace PA.Common.Exceptions
{
    public class InvalidLoginOrPasswordException : BaseException
    {
        public InvalidLoginOrPasswordException() : base("Invalid Login/Password")
        {
            
        }   
    }
}