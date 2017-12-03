using System;

namespace Container
{
    public class UnknownTypeException : Exception
    {
        public UnknownTypeException(string message) : base(message) {}
    }
}