using System;

namespace Interview.Exceptions
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message)
        {
            
        }
    }
}