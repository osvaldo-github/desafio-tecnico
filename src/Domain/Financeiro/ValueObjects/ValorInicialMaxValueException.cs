namespace Domain.Financeiro.ValueObjects
{
    using System;

    public sealed class ValorInicialMaxValueException : DomainException
    {
        internal ValorInicialMaxValueException(string message)
            : base(message)
        {
        }

        public ValorInicialMaxValueException()
        {
        }

        public ValorInicialMaxValueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}