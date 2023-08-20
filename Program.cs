string input = Console.ReadLine();

var digits = input.Split(' ').Select(c => Convert.ToInt32(c)).ToArray();

Console.WriteLine(input);

var output = GetLongestIncreasingSubsequence(digits);

Console.WriteLine(String.Join(", ", output));
Console.ReadKey();


static int[] GetLongestIncreasingSubsequence(int[] numbers)
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
