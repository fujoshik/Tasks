using System.Collections;

namespace Task5._1
{
    public class SparseMatrix : IEnumerable<long>
    {
        private Dictionary<Tuple<int,int>, long> _elements;
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
            _elements = new Dictionary<Tuple<int, int>, long>();
        }

        public long this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= Rows || j >= Columns)
                {
                    throw new IndexOutOfRangeException("Indexes must be greater than 0 and less than the size of the matrix");
                }

                var key = new Tuple<int, int>(i, j);
                return _elements.ContainsKey(key) ? _elements[key] : 0;
            }
            set
            {
                if (i < 0 || j < 0 || i >= Rows || j >= Columns)
                {
                    throw new IndexOutOfRangeException("Indexes must be greater than 0 and less than the size of the matrix");
                }

                var key = new Tuple<int, int>(i, j);

                if (_elements.ContainsKey(key))
                {
                    _elements[key] = value;
                }
                else
                {
                    _elements.Add(key, value);
                }
            }
        }

        public override string ToString()
        {
            string result = "Elements: ";

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (_elements[new Tuple<int,int>(i, j)] != 0)
                    {
                        result += $"{_elements[new Tuple<int, int>(i, j)]} ";
                    }                      
                }
            }

            return result;
        }

        public IEnumerator<long> GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    yield return this[i, j];
                }
            }
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
                    if (_elements[new Tuple<int, int>(j, i)] != 0)
                    {
                        result.Add((j, i, _elements[new Tuple<int, int>(j, i)]));
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
                    if (_elements[new Tuple<int,int>(i, j)] == x)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
