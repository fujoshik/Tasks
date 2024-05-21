using Task4._1;

namespace Tests2
{
    [TestClass]
    public class Task1Tests
    {
        [TestMethod]
        public void Index_OnMainDiagonal_CorrectValue()
        {
            var matrix = new GenericDiagonalMatrix<int>(2);
            matrix[0, 0] = 1;
            matrix[1, 1] = 5;

            Assert.AreEqual(5, matrix[1, 1]);
        }

        [TestMethod]
        public void Index_NotOnMainDiagonal_Default()
        {
            var matrix = new GenericDiagonalMatrix<int>(2);
            matrix[0, 0] = 1;
            matrix[1, 1] = 1;

            Assert.AreEqual(default, matrix[0, 1]);
        }

        [TestMethod]
        public void Add_DifferentSizes()
        {
            var matrix1 = new GenericDiagonalMatrix<int>(3);
            matrix1[0, 0] = 1;
            matrix1[1, 1] = 1;
            matrix1[2, 2] = 1;

            var matrix2 = new GenericDiagonalMatrix<int>(4);
            matrix2[0, 0] = 2;
            matrix2[1, 1] = 2;
            matrix2[2, 2] = 2;
            matrix2[3, 3] = 2;

            var expected = new GenericDiagonalMatrix<int>(4);
            expected[0, 0] = 3;
            expected[1, 1] = 3;
            expected[2, 2] = 3;
            expected[3, 3] = 2;

            var actual = matrix1.Add(matrix2, (x, y) => x + y);

            Assert.AreEqual(expected[0,0], actual[0,0]);
            Assert.AreEqual(expected[1,1], actual[1,1]);
            Assert.AreEqual(expected[2,2], actual[2,2]);
            Assert.AreEqual(expected[3,3], actual[3,3]);
        }

        [TestMethod]
        public void Tracker_UndoEvent_Success()
        {
            var matrix = new GenericDiagonalMatrix<int>(3);
            matrix[0, 0] = 1;
            matrix[1, 1] = 1;
            matrix[2, 2] = 1;

            var tracker = new MatrixTracker<int>(matrix);

            matrix[2, 2] = 6;
            Assert.AreEqual(6, matrix[2, 2]);

            tracker.Undo();
            Assert.AreEqual(1, matrix[2, 2]);
        }
    }
}