using Task2._1;

namespace Tests
{
    [TestClass]
    public class Task1Tests
    {
        [TestMethod]
        public void Mass_NegativeValue_Zero()
        {
            var p = new Point(1, 2, 3, -5);

            var expected = 0;
            var actual = p.Mass;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Mass_PositiveValue_Value()
        {
            var p = new Point(1, 2, 3, 25);

            var expected = 25;
            var actual = p.Mass;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsZero_ZeroCoordinates_True()
        {
            var p = new Point(0, 0, 0, 1);

            Assert.IsTrue(p.IsZero());
        }

        [TestMethod]
        public void IsZero_NotZeroCoordinates_False()
        {
            var p = new Point(1, 1, 1, 5);

            Assert.IsFalse(p.IsZero());
        }

        [TestMethod]
        public void CalculateDistance()
        {
            var p1 = new Point(1, 1, 1, 5);
            var p2 = new Point(10, 10, 10, 15);

            var expected = 15.59;
            var actual = Math.Round(p1.CalculateDistance(p2), 2);

            Assert.AreEqual(expected, actual);
        }
    }
}