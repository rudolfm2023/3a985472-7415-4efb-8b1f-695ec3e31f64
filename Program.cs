using static LongestIncreasingSubsequence;

int caseNumber = 1;
string instructions = "Press Escape (Esc) to exit, Enter to see result";
string inputTitle = "Please enter your numbers seperated by space.";
string input = string.Empty;

Console.WriteLine($"{instructions}");
Console.WriteLine($"{inputTitle} Test case - {caseNumber}");

do
{
    ConsoleKeyInfo key;
    key = Console.ReadKey();

    if (key.Key == ConsoleKey.Escape)
    {
        break;
    }

    if (key.Key == ConsoleKey.Enter)
    {
        if (input.Trim().Length > 0)
        {
            var digits = input.Split(' ').Select(c => Convert.ToInt32(c)).ToArray();
            var output = GetLongestIncreasingSubsequence(digits);

            Console.WriteLine();
            Console.WriteLine("Input");
            Console.WriteLine(input);
            Console.WriteLine("Output");
            Console.WriteLine(String.Join(", ", output));

            ++caseNumber;
            input = string.Empty;

            Console.WriteLine();
            Console.WriteLine($"{inputTitle} Test case - {caseNumber}");
        }
        else
        {
            Console.WriteLine("No Input available");
            Console.WriteLine($"{inputTitle} Test case - {caseNumber}");
        }
    }
    else
    {
        input = input + key.KeyChar;
    }

} while (true);

public class LongestIncreasingSubsequence
{
    public static int[] GetLongestIncreasingSubsequence(int[] numbers)
    {
        int[] lengths = new int[numbers.Length];
        int[] previousIndices = new int[numbers.Length];
        int maxLength = 0;
        int lastIndex = -1;

        for (int i = 0; i < numbers.Length; i++)
        {
            lengths[i] = 1;
            previousIndices[i] = -1;

            for (int j = 0; j < i; j++)
            {
                if (numbers[i] > numbers[j] && lengths[j] + 1 > lengths[i])
                {
                    lengths[i] = lengths[j] + 1;
                    previousIndices[i] = j;
                }
            }

            if (lengths[i] > maxLength)
            {
                maxLength = lengths[i];
                lastIndex = i;
            }
        }

        var longestSubsequence = new int[maxLength];

        for (int i = maxLength - 1; i >= 0; i--)
        {
            longestSubsequence[i] = numbers[lastIndex];
            lastIndex = previousIndices[lastIndex];
        }

        return longestSubsequence;
    }
}