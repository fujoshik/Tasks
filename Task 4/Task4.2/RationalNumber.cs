namespace Task4._2
{
    public sealed class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        public RationalNumber(int numerator, int denumerator)
        {
            if (denumerator == 0)
            {
                throw new ArgumentException("Denumerator cannot be 0!");
            }

            int greatestCommonDivisor = GreatestCommonDivisor(numerator, denumerator);
            Numerator = numerator / greatestCommonDivisor;
            Denominator = denumerator / greatestCommonDivisor;

            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        private int GreatestCommonDivisor(int a, int b)
        {
            if (a < 0)
            {
                a = -a;
            }
            if (b < 0)
            {
                b = -b;
            }

            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }            
                else
                {
                    b %= a;
                }                    
            }

            return a | b;
        }

        private int LeastCommonMultiple(int a, int b)
        {
            return a / GreatestCommonDivisor(a, b) * b;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is RationalNumber number)
            {
                if (Numerator == number.Numerator && Denominator == number.Denominator)
                {
                    return true;
                }
            }
            return false;
        }

        public int CompareTo(RationalNumber? other)
        {
            if (other == null)
            {
                return 1;
            }
            return (Numerator * other.Denominator).CompareTo(other.Numerator * Denominator);
        }

        public static RationalNumber operator +(RationalNumber left, RationalNumber right)
        {
            int numerator = left.Numerator * right.Denominator + right.Numerator * left.Denominator;
            int denominator = left.Denominator * right.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator -(RationalNumber left, RationalNumber right)
        {
            int numerator = left.Numerator * right.Denominator - right.Numerator * left.Denominator;
            int denominator = left.Denominator * right.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator *(RationalNumber left, RationalNumber right)
        {
            int numerator = left.Numerator * right.Numerator;
            int denominator = left.Denominator * right.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator /(RationalNumber left, RationalNumber right)
        {
            if (right.Numerator == 0)
            {
                throw new DivideByZeroException("Can't divide by 0!");
            }

            int numerator = left.Numerator * right.Denominator;
            int denominator = left.Denominator * right.Numerator;
            return new RationalNumber(numerator, denominator);
        }

        public static explicit operator double(RationalNumber number)
        {
            return (double)number.Numerator / number.Denominator;
        }

        public static implicit operator RationalNumber(int number)
        {
            return new RationalNumber(number, 1);
        }
    }
}
