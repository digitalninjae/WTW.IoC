using System;

namespace IoC
{
    public class UnknownTypeException : Exception
    {
        public UnknownTypeException(string message) : base(message) {}
    }
}