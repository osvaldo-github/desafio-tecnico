namespace Domain.Financeiro.ValueObjects
{
    using System;

    public sealed class JuroShouldBeLessOrEqualToOneException : DomainException
    {
        internal JuroShouldBeLessOrEqualToOneException(string message)
            : base(message)
        {
        }

        public JuroShouldBeLessOrEqualToOneException()
        {
        }

        public JuroShouldBeLessOrEqualToOneException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}