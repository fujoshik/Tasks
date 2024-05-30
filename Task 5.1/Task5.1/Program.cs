using Task5._1;

SparseMatrix matrix = new SparseMatrix(3, 2);
matrix[0, 0] = 1;
matrix[0, 1] = 0;
matrix[1, 0] = 3;
matrix[1, 1] = 0;
matrix[2, 0] = 2;
matrix[2, 1] = 0;

Console.WriteLine(matrix.GetCount(0));

var nonzeroElements = matrix.GetNonzeroElements();
Console.WriteLine(string.Join(" ", nonzeroElements));

