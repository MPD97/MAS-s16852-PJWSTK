using System;
using System.Runtime.Serialization;

namespace MP02
{
    [Serializable]
    public class ClassNotFoundException : Exception
    {
        private object p;

        public ClassNotFoundException()
        {
        }

        public ClassNotFoundException(object p)
        {
            this.p = p;
        }

        public ClassNotFoundException(string message) : base(message)
        {
        }

        public ClassNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClassNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}