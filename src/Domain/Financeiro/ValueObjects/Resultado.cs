namespace Domain.Financeiro.ValueObjects
{
    using System;

    public readonly struct Resultado : IEquatable<Resultado>
    {
        private readonly decimal resultado;

        public Resultado(decimal value)
        {
            this.resultado = value;
        }

        public decimal ToDecimal() => this.resultado;

        internal bool IsZero()
        {
            return this.resultado == 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is Resultado resultadoObj)
            {
                return this.Equals(resultadoObj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.resultado.GetHashCode();
        }

        public static bool operator ==(Resultado left, Resultado right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Resultado left, Resultado right)
        {
            return !(left == right);
        }

        public bool Equals(Resultado other)
        {
            return this.resultado == other.resultado;
        }
    }
}