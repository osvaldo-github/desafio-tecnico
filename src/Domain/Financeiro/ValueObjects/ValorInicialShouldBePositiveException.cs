namespace Domain.Financeiro.ValueObjects
{
    using System;

    public sealed class ValorInicialShouldBePositiveException : DomainException
    {
        internal ValorInicialShouldBePositiveException(string message)
            : base(message)
        {
        }

        public ValorInicialShouldBePositiveException()
        {
        }

        public ValorInicialShouldBePositiveException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}