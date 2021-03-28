using System;

namespace PA_API.Exceptions
{
    public class InvalidLoginOrPasswordException : Exception
    {
        public InvalidLoginOrPasswordException() : base("Invalid Login/Password")
        {
            
        }   
    }
}