namespace Domain.Financeiro.ValueObjects
{
    using System;

    public readonly struct ValorInicial : IEquatable<ValorInicial>
    {
        private readonly decimal valorInicial;

        public ValorInicial(decimal value)
        {
            if (value < 0)
            {
                throw new ValorInicialShouldBePositiveException(Messages.TheValorInicialShouldBePositive);
            }

            if (value > 10000000000000)
            {
                throw new ValorInicialMaxValueException(Messages.TheValorInicialMaxValue);
            }

            this.valorInicial = value;
        }

        public decimal ToDecimal() => this.valorInicial;

        internal bool IsZero()
        {
            return this.valorInicial == 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is ValorInicial valorInicialObj)
            {
                return this.Equals(valorInicialObj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.valorInicial.GetHashCode();
        }

        public static bool operator ==(ValorInicial left, ValorInicial right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ValorInicial left, ValorInicial right)
        {
            return !(left == right);
        }

        public bool Equals(ValorInicial other)
        {
            return this.valorInicial == other.valorInicial;
        }
    }
}