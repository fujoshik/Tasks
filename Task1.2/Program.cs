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
        int length = input.Length;
        int inputNum = int.Parse(input);
        int sum = 0;

        for (int i = 0; i < length; i++)
        {
            sum += (inputNum / (int)Math.Pow(10, length - 1 - i)) * (length + 1 - i);
            inputNum = inputNum % (int)Math.Pow(10, length - 1 - i);
        }

        int checkDigit = 11 - (sum % 11);

        return checkDigit == 10 ? "X" : checkDigit.ToString();
    }
}
