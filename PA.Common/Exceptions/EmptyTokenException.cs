namespace PA.Common.Exceptions
{
    public class EmptyTokenException : BaseException
    {
        public EmptyTokenException() : base("Token inválido")
        {
        }
    }
}