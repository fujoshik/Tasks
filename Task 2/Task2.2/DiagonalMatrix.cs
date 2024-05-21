namespace Task2._2
{
    public class DiagonalMatrix
    {
        public int[] Elements { get; set; }
        public int Size { get; private set; }

        public DiagonalMatrix(params int[] elements)
        {
            if (elements == null)
            {
                Elements = new int[0];
            }
            else
            {
                Size = elements.Length;
                Elements = new int[Size];              
                Array.Copy(elements, Elements, Size);
            }
        }

        public int this[int i, int j]
        {
            get
            {
                return (i == j && i > 0 && i < Size) ? Elements[i] : 0;
            }
            set
            {
                if (i == j && i > 0 && i < Size)
                {
                    Elements[i] = value;
                }
            }
        }

        public int Track()
        {
            int sum = 0;

            foreach (var element in Elements)
            {
                sum += element;
            }

            return sum;
        }

        public override bool Equals(object? obj)
        {
            if (obj is DiagonalMatrix matrix && matrix.Size == Size)
            {
                for (var i = 0; i < Elements.Length; i++)
                {
                    if (matrix.Elements[i] != Elements[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format($"Diagonal matrix with size {Size} has elements: {string.Join(" ", Elements)} and sum of elements {Track()}");
        }
    }
}
