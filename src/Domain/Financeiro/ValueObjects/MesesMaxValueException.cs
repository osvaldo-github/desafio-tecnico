namespace Domain.Financeiro.ValueObjects
{
    using System;

    public sealed class MesesMaxValueException : DomainException
    {
        internal MesesMaxValueException(string message)
            : base(message)
        {
        }

        public MesesMaxValueException()
        {
        }

        public MesesMaxValueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}