namespace Domain.Financeiro.ValueObjects
{
    using System;

    public readonly struct Meses : IEquatable<Meses>
    {
        private readonly int meses;

        public Meses(int value)
        {
            if (value < 0)
            {
                throw new MesesShouldBePositiveException(Messages.TheMesesShouldBePositive);
            }

            if (value > 1200)
            {
                throw new MesesMaxValueException(Messages.TheMesesMaxValue);
            }

            this.meses = value;
        }

        public int ToInt() => this.meses;

        internal bool IsZero()
        {
            return this.meses == 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is Meses mesesObj)
            {
                return this.Equals(mesesObj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.meses.GetHashCode();
        }

        public static bool operator ==(Meses left, Meses right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Meses left, Meses right)
        {
            return !(left == right);
        }

        public bool Equals(Meses other)
        {
            return this.meses == other.meses;
        }
    }
}