using System;

namespace Paint.Exceptions
{
    class ColorValueException : ArgumentException
    {
        public string Value { get; }
        public ColorValueException( string message, string val )
            : base( message )
        {
            Value = val;
        }
    }
}
