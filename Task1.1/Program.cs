public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Input first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Input second number: ");
        int b = int.Parse(Console.ReadLine());

        for (int i = a; i <= b; i++)
        {
            var duodecimal = DecimalToDuodecimal(i);
            if (HasTwoASymbols(duodecimal))
            {
                Console.WriteLine(i);
            }
        }
    }
    public static bool HasTwoASymbols(string num)
    {
        int count = 0;

        foreach (var x in num)
        {
            if (x == 'A')
            {
                count++;
            }
        }
        return count == 2;
    }

    public static string DecimalToDuodecimal(int decimalNum)
    {
        string duodecimal = "";

        while (decimalNum > 0)
        {
            var remainder = decimalNum % 12;

            if (remainder < 10)
            {
                duodecimal = remainder + duodecimal;
            }
            else if (remainder == 10)
            {
                duodecimal = "A" + duodecimal;
            }
            else if (remainder == 11)
            {
                duodecimal = "B" + duodecimal;
            }

            decimalNum /= 12;
        }

        return duodecimal;
    }
}
