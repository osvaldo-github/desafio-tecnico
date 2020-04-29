namespace Domain.Financeiro
{
    using System;

    public sealed class FinanceiroExternalIntegrationException : DomainException
    {
        public FinanceiroExternalIntegrationException(string message)
            : base(message)
        {
        }

        public FinanceiroExternalIntegrationException() : base(string.Empty)
        {
        }

        public FinanceiroExternalIntegrationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}