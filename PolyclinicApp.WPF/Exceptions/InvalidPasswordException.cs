﻿using System;
using System.Runtime.Serialization;

namespace PolyclinicApp.WPF.Exceptions
{
    internal class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
        {
        }

        public InvalidPasswordException(string? message) : base(message)
        {
        }

        public InvalidPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public InvalidPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}