namespace Task2._1
{
    public class Point
    {
        private int[] _coordinates;
        private double _mass;

        public Point(int x, int y, int z, double mass)
        {
            _coordinates = new int[3];
            X = x; 
            Y = y; 
            Z = z;
            Mass = mass;
        }

        public int X 
        { 
            get => _coordinates[0];
            set => _coordinates[0] = value;
        }
        public int Y
        {
            get => _coordinates[1];
            set => _coordinates[1] = value;
        }
        public int Z 
        {
            get => _coordinates[2];
            set => _coordinates[2] = value;
        }
        public double Mass 
        { 
            get => _mass;
            set => _mass = value > 0 ? value : 0;
        }

        public bool IsZero()
        {
            return X == 0 && Y == 0 && Z == 0;
        }

        public double CalculateDistance(Point point)
        {
            return Math.Sqrt(
                Math.Pow(_coordinates[0] - point._coordinates[0], 2) +
                Math.Pow(_coordinates[1] - point._coordinates[1], 2) +
                Math.Pow(_coordinates[2] - point._coordinates[2], 2));
        }

        public override string ToString()
        {
            return string.Format($"X : {X}, Y : {Y}, Z : {Z}, Mass : {Mass}");
        }
    }
}
