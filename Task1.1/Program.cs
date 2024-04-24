public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Input first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Input second number: ");
        int b = int.Parse(Console.ReadLine());

        int start = Math.Min(a, b);
        int end = Math.Max(a, b);

        for (int i = start; i <= end; i++)
        {
            if (HasTwoASymbols(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    public static bool HasTwoASymbols(int decimalNum)
    {
        int count = 0;

        while (decimalNum > 0)
        {
            var remainder = decimalNum % 12;

            if (Math.Abs(remainder) == 10)
            {
                count++;
            }
            decimalNum /= 12;
        }
        return count == 2;
    }
}
