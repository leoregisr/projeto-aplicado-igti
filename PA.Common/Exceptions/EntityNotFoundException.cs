namespace PA.Common.Exceptions
{
    public class EntityNotFoundException<T> : BaseException
    {
        public EntityNotFoundException(int id) : base($"Entity {typeof(T).Name} with {id} identifier not found")
        {   
        }

        public EntityNotFoundException(string id) : base($"Entity {typeof(T).Name} with {id} identifier not found")
        {
        }
    }
}