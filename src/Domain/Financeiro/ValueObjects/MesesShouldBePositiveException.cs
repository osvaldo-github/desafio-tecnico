namespace Domain.Financeiro.ValueObjects
{
    using System;

    public sealed class MesesShouldBePositiveException : DomainException
    {
        internal MesesShouldBePositiveException(string message)
            : base(message)
        {
        }

        public MesesShouldBePositiveException()
        {
        }

        public MesesShouldBePositiveException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}