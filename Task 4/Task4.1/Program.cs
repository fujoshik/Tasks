using Task4._1;

var matrix1 = new GenericDiagonalMatrix<int>(3);
matrix1[0,0] = 1;
matrix1[1,1] = 1;
matrix1[2,2] = 1;

var matrix2 = new GenericDiagonalMatrix<int>(4);
matrix2[0, 0] = 2;
matrix2[1, 1] = 2;
matrix2[2, 2] = 2;
matrix2[3, 3] = 2;

Console.WriteLine("Adding matrices:");
var result = matrix1.Add(matrix2, (x, y) => x+y);
Console.WriteLine();

var tracker = new MatrixTracker<int>(result);
result[3, 3] = 10;
tracker.Undo();
