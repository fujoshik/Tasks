using System.Collections;
using System.Text;
using System.Xml.Linq;

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
                    if (value != 0)
                    {
                        _elements[key] = value;
                    }
                    else
                    {
                        _elements.Remove(key);
                    }
                }
                else if (value != 0)
                {
                    _elements.Add(key, value);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("Elements: ");

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result.Append($"{_elements[new Tuple<int, int>(i, j)]} ");
                }
            }

            return result.ToString();
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
            return _elements
                .OrderBy(x => x.Key.Item2)
                .ThenBy(x => x.Key.Item1)
                .Select(x => (x.Key.Item1, x.Key.Item2, x.Value));
        }

        public int GetCount(int x)
        {
            if (x == 0)
            {
                return Rows * Columns - _elements.Count;
            }            
            return _elements.Count(e => e.Value == x);
        }
    }
}
