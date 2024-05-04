using Task2._2;

var matrix1 = new DiagonalMatrix(1, 2, 3);
Console.WriteLine(matrix1.ToString());
Console.WriteLine(matrix1[1, 5]);
Console.WriteLine();

var matrix2 = new DiagonalMatrix(4, 5, 6, 7);
Console.WriteLine(matrix2.ToString());
Console.WriteLine();

Console.WriteLine("Adding matrices:");
Console.WriteLine(matrix1.Add(matrix2));
