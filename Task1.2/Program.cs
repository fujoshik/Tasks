public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Input the first 9 digits of the ISBN: ");
        string input = Console.ReadLine();

        string isbn = input + CalculateCheckDigit(input);
        Console.WriteLine(isbn);
    }

    public static string CalculateCheckDigit(string input)
    {
        int number = int.Parse(input);
        int sum = 0;

        for (int i = 2; i <= 10; i++)
        {
            var digit = number % 10;
            number /= 10;
            sum += i * digit;
        }

        int checkDigit = (11 - (sum % 11)) % 11;

        return checkDigit == 10 ? "X" : checkDigit.ToString();
    }
}
