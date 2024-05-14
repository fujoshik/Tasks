namespace Task4._1
{
    public class GenericDiagonalMatrix<T>
    {
        public event EventHandler<GenericMatrixElementChangedEventArgs<T>>? ElementChanged;

        private T[] _elements;
        public int Size { get; private set; }

        public GenericDiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Size must be a positive number!");
            }
            Size = size;
            _elements = new T[size];
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= Size || j >= Size)
                {
                    throw new IndexOutOfRangeException("Indexes must be greater than 0 and less than the size of the matrix");
                }
                return (i == j && i >= 0 && i < Size) ? _elements[i] : default;
            }
            set
            {
                if (!(i == j && i >= 0 && i < Size))
                {
                    throw new IndexOutOfRangeException("Indexes must be greater than 0 and less than the size of the matrix");
                }
                if (!value.Equals(_elements[i]))
                {               
                    ElementChanged?.Invoke(this, new GenericMatrixElementChangedEventArgs<T>(i, j, _elements[i], value));
                    _elements[i] = value;
                }
            }
        }
    }
}
