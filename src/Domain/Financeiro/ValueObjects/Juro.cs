namespace Domain.Financeiro.ValueObjects
{
    using System;

    public readonly struct Juro : IEquatable<Juro>
    {
        private readonly decimal juro;

        public Juro(decimal value)
        {
            if (value < 0)
            {
                throw new JuroShouldBePositiveException(Messages.TheJuroShouldBePositive);
            }

            if (value > 1)
            {
                throw new JuroShouldBeLessOrEqualToOneException(Messages.TheJuroShouldBeLessOrEqualToOne);
            }


            this.juro = value;
        }

        public decimal ToDecimal() => this.juro;

        internal bool IsZero()
        {
            return this.juro == 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is Juro juroObj)
            {
                return this.Equals(juroObj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.juro.GetHashCode();
        }

        public static bool operator ==(Juro left, Juro right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Juro left, Juro right)
        {
            return !(left == right);
        }

        public bool Equals(Juro other)
        {
            return this.juro == other.juro;
        }
    }
}