namespace Task4._1
{
    public static class GenericDiagonalMatrixExtentions
    {
        public static GenericDiagonalMatrix<T> Add<T>(
            this GenericDiagonalMatrix<T> a, 
            GenericDiagonalMatrix<T> b, 
            Func<T, T, T> function)
        {
            int biggerSize = int.Max(a.Size, b.Size);
            GenericDiagonalMatrix<T> newMatrix = new(biggerSize);

            for (int i = 0; i < biggerSize; i++)
            {
                if (i < a.Size && i < b.Size)
                {
                    newMatrix[i, i] = function(a[i, i], b[i, i]);
                }
                else if (i < a.Size)
                {
                    newMatrix[i, i] = function(a[i, i], default);
                }
                else
                {
                    newMatrix[i,i] = function(default, b[i, i]);
                }
            }

            return newMatrix;
        }
    }
}
