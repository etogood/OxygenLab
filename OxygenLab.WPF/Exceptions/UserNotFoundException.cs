using System;
using System.Runtime.Serialization;

namespace OxygenLab.WPF.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string? message) : base(message)
        {
        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}