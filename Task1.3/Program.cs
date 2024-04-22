public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Input array:");
        var input = Console.ReadLine().Split(", ").ToArray();

        var array = new int[input.Length];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(input[i]);
        }
        Console.WriteLine("Array: " + string.Join(" ", array));

        var uniqueIntegers = FindUniqueValues(array);

        Console.Write("Unique integers: ");
        for (int i = 0; i < uniqueIntegers.Length; i++)
        {
            Console.Write($"{uniqueIntegers[i]} ");
        }
    }

    public static int[] FindUniqueValues(int[] array)
    {
        int[] uniqueIntegers = new int[array.Length];
        int uniqueIntegersCount = 0;

        for (int i = 0; i < array.Length; i++)
        {
            int j;
            for (j = 0; j < i; j++)
            {
                if (array[i] == array[j])
                {
                    break;
                }
            }
            if (i == j)
            {
                uniqueIntegers[uniqueIntegersCount] = array[i];
                uniqueIntegersCount++;
            }
        }

        return uniqueIntegers;
    }
}
