using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Testo
{
    public class AssertionException : Exception
    {
        public AssertionException(string message) : base(message)
        {
        }

        protected AssertionException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}