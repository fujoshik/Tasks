using Task4._2;

namespace Tests
{
    [TestClass]
    public class Task2Tests
    {
        [TestMethod]
        public void Constructor_InvalidDenominator_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new RationalNumber(5, 0));
        }

        [TestMethod]
        public void Equals_EqualNumbers_True()
        {
            var number1 = new RationalNumber(2, 3);
            var number2 = new RationalNumber(2, 3);

            Assert.IsTrue(number1.Equals(number2));
        }

        [TestMethod]
        public void Equals_NotEqualNumbers_False()
        {
            var number1 = new RationalNumber(2, 3);
            var number2 = new RationalNumber(10, 3);

            Assert.IsFalse(number1.Equals(number2));
        }

        [TestMethod]
        public void Addition_Success()
        {
            var number1 = new RationalNumber(1, 3);
            var number2 = new RationalNumber(7, 8);

            var expected = new RationalNumber(29, 24);
            var actual = number1 + number2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Substraction_Success()
        {
            var number1 = new RationalNumber(1, 3);
            var number2 = new RationalNumber(7, 8);

            var expected = new RationalNumber(-13, 24);
            var actual = number1 - number2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiplication_Success()
        {
            var number1 = new RationalNumber(1, 3);
            var number2 = new RationalNumber(7, 8);

            var expected = new RationalNumber(7, 24);
            var actual = number1 * number2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Division_Success()
        {
            var number1 = new RationalNumber(1, 3);
            var number2 = new RationalNumber(7, 8);

            var expected = new RationalNumber(8, 21);
            var actual = number1 / number2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExplicitCastToDouble_Success()
        {
            var number = new RationalNumber(1, 2);
            double expected = 0.5;

            Assert.AreEqual(expected, (double)number);
        }

        [TestMethod]
        public void ImplicitCastIntToRationalNumber_Success()
        {
            RationalNumber number = 5;
            var expected = new RationalNumber(5, 1);

            Assert.AreEqual(expected, number);
        }
    }
}