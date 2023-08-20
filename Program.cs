string input = Console.ReadLine();

var digits = input.Split(' ').Select(c => Convert.ToInt32(c)).ToArray();

Console.WriteLine(input);
