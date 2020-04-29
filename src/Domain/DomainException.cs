namespace Domain
{
    using System;

    public class DomainException : Exception
    {
        public DomainException(string businessMessage)
            : base(businessMessage)
        {
        }

        public DomainException()

        {
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}