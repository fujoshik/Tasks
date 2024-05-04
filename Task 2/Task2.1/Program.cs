using Task2._1;

Point p1 = new Point(0, 0, 0, -1);
Point p2 = new Point(10, 10, 10, 5);

Console.WriteLine(p1.ToString());
Console.WriteLine("Is zero: " + p1.IsZero());

Console.WriteLine(p2.ToString());
Console.WriteLine("Is zero: " + p2.IsZero());

Console.WriteLine("Distance: " + p1.CalculateDistance(p2));
