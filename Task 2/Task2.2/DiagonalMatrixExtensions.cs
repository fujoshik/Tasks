namespace Task2._2
{
    public static class DiagonalMatrixExtensions
    {
        public static DiagonalMatrix Add(this DiagonalMatrix a, DiagonalMatrix b)
        {
            int biggerSize = int.Max(a.Size, b.Size);
            var newMatrix = new int[biggerSize];

            for (int i = 0; i < biggerSize; i++)
            {
                if (i < a.Size && i < b.Size)
                {
                    newMatrix[i] = a.Elements[i] + b.Elements[i];
                }
                else if (i < a.Size)
                {
                    newMatrix[i] = a.Elements[i];
                }
                else
                {
                    newMatrix[i] = b.Elements[i];
                }
            }

            return new DiagonalMatrix(newMatrix);
        }
    }
}
