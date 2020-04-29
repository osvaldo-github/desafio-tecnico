namespace Domain.Financeiro.ValueObjects
{
    using System;

    public sealed class JuroShouldBePositiveException : DomainException
    {
        internal JuroShouldBePositiveException(string message)
            : base(message)
        {
        }

        public JuroShouldBePositiveException()
        {
        }

        public JuroShouldBePositiveException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}