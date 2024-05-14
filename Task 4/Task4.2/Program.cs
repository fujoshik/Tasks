using Task4._2;

var num1 = new RationalNumber(4, 12);
var num2 = new RationalNumber(1, 5);

Console.WriteLine($"4/12 = {num1}");

var num3 = new RationalNumber(1, 3);
Console.WriteLine($"Equals? {num3.Equals(num1)}");

Console.WriteLine($"Compare to: {num1.CompareTo(num2)}");
Console.WriteLine($"num1 + num2 = {num1 + num2}");
Console.WriteLine($"num1 - num2 = {num1 - num2}");
Console.WriteLine($"num1 * num2 = {num1 * num2}");
Console.WriteLine($"num1 / num2 = {num1 / num2}");

Console.WriteLine($"{num1} = {(double)num1}");

RationalNumber implicitCast = 2;
Console.WriteLine(implicitCast);
