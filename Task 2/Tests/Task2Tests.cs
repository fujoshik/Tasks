using Task2._2;

namespace Tests
{
    [TestClass]
    public class Task2Tests
    {
        [TestMethod]
        public void Equals_DifferentElements_False()
        {
            var matrix1 = new DiagonalMatrix(1, 2, 3);
            var matrix2 = new DiagonalMatrix(1, 2, 5);

            var actual = matrix1.Equals(matrix2);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Equals_DifferentSizes_False()
        {
            var matrix1 = new DiagonalMatrix(1, 2, 3);
            var matrix2 = new DiagonalMatrix(1, 2, 3, 5);

            var actual = matrix1.Equals(matrix2);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Equals_SameElements_True()
        {
            var matrix1 = new DiagonalMatrix(1, 2, 3);
            var matrix2 = new DiagonalMatrix(1, 2, 3);

            var actual = matrix1.Equals(matrix2);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Track_CorrectInput_True()
        {
            var matrix1 = new DiagonalMatrix(12, 27, 3);

            var expected = 42;
            var actual = matrix1.Track();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_DifferentSizes()
        {
            var matrix1 = new DiagonalMatrix(1, 2, 3);
            var matrix2 = new DiagonalMatrix(7, 8, 9, 19, 10);

            var expected = new DiagonalMatrix(8, 10, 12, 19, 10);
            var actual = matrix1.Add(matrix2);

            Assert.AreEqual(expected, actual);
        }
    }
}
