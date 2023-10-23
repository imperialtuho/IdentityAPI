using System.Runtime.Serialization;

namespace Identity.Common.Exceptions
{
    [Serializable]
    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message)
        {
        }

        private NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}