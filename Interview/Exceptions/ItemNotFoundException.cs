using System;

namespace Interview.Exceptions
{
    public abstract class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message)
        {
            
        }
    }
}