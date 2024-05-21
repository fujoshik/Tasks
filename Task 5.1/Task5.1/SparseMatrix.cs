using System.Collections;

namespace Task5._1
{
    public class SparseMatrix : IEnumerable<long>
    {
        private long[,] _elements;
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public SparseMatrix(int rows, int columns)
        {
            if (rows <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows));
            }
            if (columns <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columns));
            }
            Rows = rows;
            Columns = columns;
            _elements = new long[rows, columns];
        }

        public long this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= Rows || j >= Columns)
                {
                    throw new IndexOutOfRangeException("Indexes must be greater than 0 and less than the size of the matrix");
                }
                return _elements[i, j];
            }
            set
            {
                if (i < 0 || j < 0 || i >= Rows || j >= Columns)
                {
                    throw new IndexOutOfRangeException("Indexes must be greater than 0 and less than the size of the matrix");
                }
                _elements[i, j] = value;
            }
        }

        public override string ToString()
        {
            string result = "Elements: ";

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (_elements[i, j] != 0)
                    {
                        result += $"{_elements[i, j]} ";
                    }                      
                }
            }

            return result;
        }

        public IEnumerator<long> GetEnumerator()
        {
            return _elements.GetEnumerator() as IEnumerator<long>;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<(int,int,long)> GetNonzeroElements()
        {
            var result = new List<(int,int,long)>();
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    if (_elements[j, i] != 0)
                    {
                        result.Add((j, i, _elements[j, i]));
                    }
                }
            }

            return result;
        }

        public int GetCount(int x)
        {
            int count = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (_elements[i, j] == x)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
