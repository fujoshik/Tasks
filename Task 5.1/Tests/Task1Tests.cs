using Task5._1;

namespace Tests
{
    [TestClass]
    public class Task1Tests
    {
        [TestMethod]
        public void Index_HasValue_CorrectValue()
        {
            var matrix = new SparseMatrix(2, 3);
            matrix[1, 1] = 5;

            Assert.AreEqual(5, matrix[1, 1]);
        }

        [TestMethod]
        public void Index_IsZero_Default()
        {
            var matrix = new SparseMatrix(2, 3);
            matrix[1, 1] = 5;

            Assert.AreEqual(default, matrix[0, 1]);
        }

        [TestMethod]
        public void GetNonzeroElements_CorrectValues_True()
        {
            var matrix = new SparseMatrix(2, 3);
            matrix[0, 0] = 3;
            matrix[0, 1] = 0;
            matrix[1, 0] = 0;
            matrix[1, 1] = 5;

            var expected = new List<(int, int, long)> { (0, 0, 3), (1, 1, 5) };
            var result = matrix.GetNonzeroElements();

            Assert.AreEqual(expected[0], result.First());
            Assert.AreEqual(expected[1], result.Last());
        }

        [TestMethod]
        public void GetNonzeroElements_IncorrectValues_True()
        {
            var matrix = new SparseMatrix(2, 3);
            matrix[0, 0] = 3;
            matrix[0, 1] = 0;
            matrix[1, 0] = 0;
            matrix[1, 1] = 5;

            var expected = new List<(int, int, long)> { (0, 1, 7), (1, 1, 4) };
            var result = matrix.GetNonzeroElements();

            Assert.AreNotEqual(expected[0], result.First());
            Assert.AreNotEqual(expected[1], result.Last());
        }

        [TestMethod]
        public void GetCount_Value_Correct()
        {
            var matrix = new SparseMatrix(2, 3);
            matrix[0, 0] = 3;
            matrix[1, 1] = 5;

            var expected = 1;
            var result = matrix.GetCount(5);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetCount_Zeros_Correct()
        {
            var matrix = new SparseMatrix(2, 3);
            matrix[0, 0] = 3;
            matrix[1, 1] = 5;

            var expected = 4;
            var result = matrix.GetCount(0);

            Assert.AreEqual(expected, result);
        }
    }
}