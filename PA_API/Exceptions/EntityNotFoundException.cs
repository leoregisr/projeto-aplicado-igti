using System;

namespace PA_API.Exceptions
{
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException(int id) : base($"Entity {typeof(T).Name} with {id} identifier not found")
        {   
        }

        public EntityNotFoundException(string id) : base($"Entity {typeof(T).Name} with {id} identifier not found")
        {
        }
    }
}